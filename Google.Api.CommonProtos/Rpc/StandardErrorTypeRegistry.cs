/*
 * Copyright 2023 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Google.Protobuf.Reflection;

namespace Google.Rpc
{
    /// <summary>
    /// Registry of the <see href="https://github.com/googleapis/googleapis/blob/master/google/rpc/error_details.proto">
    /// standard set of error types</see> defined in the richer error model developed and used by Google.
    /// These can be sepcified in the <see cref="Google.Rpc.Status.Details"/>.
    /// </summary>
    public static class StandardErrorTypeRegistry
    {
        private static readonly TypeRegistry _registry = TypeRegistry.FromMessages(
            new MessageDescriptor[]
            {
            ErrorInfo.Descriptor,
            BadRequest.Descriptor,
            RetryInfo.Descriptor,
            DebugInfo.Descriptor,
            QuotaFailure.Descriptor,
            PreconditionFailure.Descriptor,
            RequestInfo.Descriptor,
            ResourceInfo.Descriptor,
            Help.Descriptor,
            LocalizedMessage.Descriptor
            });

        /// <summary>
        /// Get the registry
        /// Note: experimental API that can change or be removed without any prior notice.
        /// </summary>
        public static TypeRegistry Registry => _registry;
    }
}
