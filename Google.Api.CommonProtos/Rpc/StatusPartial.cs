/*
 * Copyright 2023 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;
using System.Collections.Generic;
using System.Linq;

namespace Google.Rpc;

public partial class Status
{
    /// <summary>
    /// Cache the full names of the messages types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    private static class MessageNameCache<T> where T : class, IMessage<T>, new()
    {
        public static readonly string FullName = new T().Descriptor.FullName;
    }

    /// <summary>
    /// Retrieves the error details of type <typeparamref name="T"/> from the <see cref="Google.Rpc.Status"/>
    /// message.
    /// </summary>
    /// <remarks>
    /// <example>
    /// For example, to retrieve any <see cref="Google.Rpc.ErrorInfo"/> that might be in the status details:
    /// <code>
    ///   var errorInfo = status.GetStatusDetail&lt;ErrorInfo&gt;();
    ///   if (errorInfo is not null) {
    ///      // ...
    ///   }
    /// </code>
    /// </example>
    /// </remarks>
    /// <typeparam name="T">The message type to decode from within the error details.</typeparam>
    /// <returns>The first error details of type <typeparamref name="T"/> found, or null if not present</returns>
    public T GetDetail<T>() where T : class, IMessage<T>, new()
    {
        var expectedName = MessageNameCache<T>.FullName;
        var any = Details.FirstOrDefault(a => Any.GetTypeName(a.TypeUrl) == expectedName);
        if (any is null)
        {
            return null;
        }
        return any.Unpack<T>();
    }

    /// <summary>
    /// Iterate over all the messages in the <see cref="Google.Rpc.Status.Details"/>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Iterate over the messages in the <see cref="Google.Rpc.Status.Details"/> that are messages
    /// in the <see href="https://github.com/googleapis/googleapis/blob/master/google/rpc/error_details.proto">
    /// standard set of error types</see> defined in the richer error model. Any other messages found in
    /// the Details are ignored and not returned.
    /// </para>
    /// <para>
    /// <example>
    /// Example:
    /// <code>
    /// foreach (var msg in status.UnpackDetailMessages()) {
    ///   switch (msg) {
    ///     case ErrorInfo errorInfo:
    ///          // Handle errorInfo ...
    ///          break;
    ///     // Other cases ...
    ///   }
    /// }
    /// </code>
    /// </example>
    /// </para>
    /// </remarks>
    /// <returns></returns>
    public IEnumerable<IMessage> UnpackDetailMessages()
    {
        return UnpackDetailMessages(StandardErrorTypeRegistry.Registry);
    }

    /// <summary>
    /// Iterate over all the messages in the <see cref="Google.Rpc.Status.Details"/> that match types
    /// in the given <see cref="TypeRegistry"/>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Iterate over the messages in the <see cref="Google.Rpc.Status.Details"/> that are messages
    /// in the given <see cref="TypeRegistry"/>. Any other messages found in the Details are ignored
    /// and not returned.  This allows iterating over custom messages if you are not using the
    /// standard set of error types defined in the rich error model.
    /// </para>
    /// <para>
    /// <example>
    /// Example:
    /// <code>
    /// TypeRegistry myTypes = TypeRegistry.FromMessages(
    ///   new MessageDescriptor[] {
    ///     FooMessage.Descriptor, BarMessage.Descriptor
    ///   });
    ///   
    /// foreach (var msg in status.UnpackDetailMessages(myTypes)) {
    ///   switch (msg) {
    ///     case FooMessage foo:
    ///          // Handle foo ...
    ///          break;
    ///     // Other cases ...
    ///   }
    /// }
    /// </code>
    /// </example>
    /// </para>
    /// </remarks>
    /// <param name="registry"></param>
    /// <returns></returns>
    public IEnumerable<IMessage> UnpackDetailMessages(TypeRegistry registry)
    {
        foreach (var any in Details)
        {
            var msg = any.Unpack(registry);
            if (!(msg is null))
            {
                yield return msg;
            }
        }
    }
}
