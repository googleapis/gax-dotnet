/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Devtools.Source.V1;
using Google.Protobuf;
using System;
using System.IO;

namespace Google.Api.Gax
{
    /// <summary>
    /// Read source-context.json from app root.
    /// </summary>
    public static class SourceRevision
    {
        private const string SourceContextFileName = "source-context.json";
        private static Lazy<string> s_sourceContextFilePath = new Lazy<string>(FindSourceContextFile);
        private static Lazy<SourceContext> s_sourceContext = new Lazy<SourceContext>(OpenParseSourceContextFile);
        private static Lazy<string> s_gitRevisionId => new Lazy<string>(() => s_sourceContext.Value?.Git.RevisionId);

        /// <summary>
        /// Gets the custom log label of Stackdriver Logging entry for Git commit id.
        /// </summary>
        public const string GitRevisionIdLogLabel = "git_revision_id";

        /// <summary>
        /// Gets the Git revision id if it is present. 
        /// Returns null if there is no Git Repo source context found.
        /// </summary>
        public static string GitRevisionId => s_gitRevisionId.Value;

        /// <summary>
        /// Open the source context file and parse it with <seealso cref="SourceContext"/> proto.
        /// </summary>
        /// <returns>
        /// A <seealso cref="SourceContext"/> protobuf object if the file is read and parsed successfully.
        /// null is returned if error happened or the source context file is not found.
        /// </returns>
        private static SourceContext OpenParseSourceContextFile()
        {
            string sourceContext = ReadSourceContextFile();
            if (sourceContext == null)
            {
                return null;
            }

            try
            {
                return JsonParser.Default.Parse<Devtools.Source.V1.SourceContext>(sourceContext);
            }
            catch (Exception ex) when (IsProtobufParserException(ex))
            {
                return null;
            }
        }

        /// <summary>
        /// Find source context file and open the content.
        /// </summary>
        private static string ReadSourceContextFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(File.OpenRead(s_sourceContextFilePath.Value)))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex) when (IsIOException(ex))
            {
                return null;
            }
        }

        private static string FindSourceContextFile()
        {
#if NETSTANDARD1_3
            string root = AppContext.BaseDirectory;
#else
            string root = AppDomain.CurrentDomain.BaseDirectory;
#endif
            var fullPath = Path.Combine(root, SourceContextFileName);
            return File.Exists(fullPath) ? fullPath : null;
        }

        private static bool IsIOException(Exception ex)
        {
            return ex is FileNotFoundException
                || ex is DirectoryNotFoundException
                || ex is IOException;
        }

        private static bool IsProtobufParserException(Exception ex)
        {
            return ex is InvalidProtocolBufferException
                || ex is InvalidJsonException;
        }
    }
}