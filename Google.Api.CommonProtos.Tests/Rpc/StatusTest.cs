/*
 * Copyright 2023 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Google.Api;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Linq;
using Xunit;
using static Google.Rpc.BadRequest.Types;
using static Google.Rpc.Help.Types;

namespace Google.Rpc;

public class StatusTest
{
    [Fact]
    public void GetStatusDetail_AllDetails()
    {
        var status = CreateFullStatus();
        AssertDetail(CreateBadRequest());
        AssertDetail(CreateErrorInfo());
        AssertDetail(CreateRetryInfo());
        AssertDetail(CreateDebugInfo());
        AssertDetail(CreateQuotaFailure());
        AssertDetail(CreatePreconditionFailure());
        AssertDetail(CreateRequestInfo());
        AssertDetail(CreateHelp());
        AssertDetail(CreateLocalizedMessage());

        void AssertDetail<T>(T expected) where T : class, IMessage<T>, new()
        {
            var actual = status.GetDetail<T>();
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }
    }

    [Fact]
    public void GetStatusDetail_NotFound()
    {
        var status = CreatePartialStatus();
        Assert.Null(status.GetDetail<BadRequest>());
    }

    [Fact]
    public void UnpackDetailMessages()
    {
        var status = CreateFullStatus();

        var detailList = status.UnpackDetailMessages().ToList();

        // All the details should be returned by UnpackDetailMessages because we
        // know about all of them.
        Assert.Equal(status.Details.Count, detailList.Count);

        Assert.Contains(CreateBadRequest(), detailList);
        Assert.Contains(CreateErrorInfo(), detailList);
        Assert.Contains(CreateRetryInfo(), detailList);
        Assert.Contains(CreateDebugInfo(), detailList);
        Assert.Contains(CreateQuotaFailure(), detailList);
        Assert.Contains(CreatePreconditionFailure(), detailList);
        Assert.Contains(CreateRequestInfo(), detailList);
        Assert.Contains(CreateHelp(), detailList);
        Assert.Contains(CreateLocalizedMessage(), detailList);
    }

    [Fact]
    public void NonStandardDetails()
    {
        // Clearly this won't actually be in a status, but it's
        // just "a message we don't have in the registry".
        var generationSettings = new DotnetSettings { IgnoredResources = { "ignored" } };

        var status = new Status
        {
            Details =
            {
                Any.Pack(CreateBadRequest()),
                Any.Pack(generationSettings)
            }
        };

        Assert.Equal(CreateBadRequest(), status.GetDetail<BadRequest>());
        Assert.Equal(generationSettings, status.GetDetail<DotnetSettings>());

        // Standard type registry...
        var detailList = status.UnpackDetailMessages().ToList();
        Assert.Equal(1, detailList.Count());
        Assert.Contains(CreateBadRequest(), detailList);
        Assert.DoesNotContain(generationSettings, detailList);

        // Custom type registry... (no standard details)
        var customTypeRegistry = TypeRegistry.FromFiles(ClientReflection.Descriptor);
        detailList = status.UnpackDetailMessages(customTypeRegistry).ToList();
        Assert.Equal(1, detailList.Count());
        Assert.DoesNotContain(CreateBadRequest(), detailList);
        Assert.Contains(generationSettings, detailList);
    }

    private static Status CreatePartialStatus() => new()
    {
        Code = (int) Code.Unavailable,
        Message = "partial status",
        Details =
        {
            Any.Pack(CreateRetryInfo()),
            Any.Pack(CreateDebugInfo()),
        }
    };

    private static Status CreateFullStatus() => new()
    {
        Code = (int) Code.ResourceExhausted,
        Message = "Test",
        Details =
        {
            Any.Pack(CreateBadRequest()),
            Any.Pack(CreateErrorInfo()),
            Any.Pack(CreateRetryInfo()),
            Any.Pack(CreateDebugInfo()),
            Any.Pack(CreateQuotaFailure()),
            Any.Pack(CreatePreconditionFailure()),
            Any.Pack(CreateRequestInfo()),
            Any.Pack(CreateResourceInfo()),
            Any.Pack(CreateHelp()),
            Any.Pack(CreateLocalizedMessage())
        }
    };

    private static BadRequest CreateBadRequest() => new()
    {
        FieldViolations = { new FieldViolation { Field = "field", Description = "description" } }
    };

    private static RetryInfo CreateRetryInfo() => new()
    {
        RetryDelay = Duration.FromTimeSpan(new TimeSpan(0, 0, 5))
    };

    private static DebugInfo CreateDebugInfo() => new()
    {
        StackEntries = { "stack1", "stack2" },
        Detail = "detail"
    };

    private static QuotaFailure CreateQuotaFailure() => new()
    {
        Violations = { new QuotaFailure.Types.Violation { Description = "Too much disk space used", Subject = "Disk23" } }
    };

    private static PreconditionFailure CreatePreconditionFailure() => new()
    {
        Violations =
        {
            new PreconditionFailure.Types.Violation
            {
                Type = "type",
                Subject = "subject",
                Description = "description"
            }
        }
    };

    private static RequestInfo CreateRequestInfo() => new() { RequestId = "reqId", ServingData = "data" };

    private static ResourceInfo CreateResourceInfo() => new()
    {
        ResourceType = "type",
        ResourceName = "name",
        Owner = "owner",
        Description = "description"
    };

    private static Help CreateHelp() => new Help
    {
        Links =
        {
            new Link { Url = "url1", Description = "desc1" },
            new Link { Url = "url2", Description = "desc2" },
        }
    };

    private static LocalizedMessage CreateLocalizedMessage() =>
        new() { Locale = "en-GB", Message = "Example localised error message" };

    private static ErrorInfo CreateErrorInfo() => new()
    {
        Domain = "Rich Error Model Demo",
        Reason = "Full error requested in the demo",
        Metadata =
        {
            { "key1", "value1" },
            { "key2", "value2" }
        }
    };
}
