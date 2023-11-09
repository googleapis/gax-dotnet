/*
 * Copyright 2023 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using Xunit;

namespace Google.Rpc;

public class StatusTest
{
    [Fact]
    public void GetStatusDetailTest()
    {
        // Arrange - create a status
        // The detailsMap contains all the Messages added to the status so
        // these can be used in the comparisions when then are retrieved later
        var detailsMap = new Dictionary<string, IMessage>();
        var status = CreateFullStatus(detailsMap);

        // Act
        var badRequest = status.GetDetail<BadRequest>();
        // Assert
        Assert.NotNull(badRequest);
        var expected = detailsMap["badRequest"];
        Assert.Equal(expected, badRequest);

        // Act
        var errorInfo = status.GetDetail<ErrorInfo>();
        // Assert
        Assert.NotNull(errorInfo);
        expected = detailsMap["errorInfo"];
        Assert.Equal(expected, errorInfo);

        // Act
        var retryInfo = status.GetDetail<RetryInfo>();
        // Assert
        Assert.NotNull(retryInfo);
        expected = detailsMap["retryInfo"];
        Assert.Equal(expected, retryInfo);

        // Act
        var debugInfo = status.GetDetail<DebugInfo>();
        // Assert
        Assert.NotNull(debugInfo);
        expected = detailsMap["debugInfo"];
        Assert.Equal(expected, debugInfo);

        // Act
        var quotaFailure = status.GetDetail<QuotaFailure>();
        // Assert
        Assert.NotNull(quotaFailure);
        expected = detailsMap["quotaFailure"];
        Assert.Equal(expected, quotaFailure);

        // Act
        var preconditionFailure = status.GetDetail<PreconditionFailure>();
        // Assert
        Assert.NotNull(preconditionFailure);
        expected = detailsMap["preconditionFailure"];
        Assert.Equal(expected, preconditionFailure);

        // Act
        var requestInfo = status.GetDetail<RequestInfo>();
        // Assert
        Assert.NotNull(requestInfo);
        expected = detailsMap["requestInfo"];
        Assert.Equal(expected, requestInfo);

        // Act
        var help = status.GetDetail<Help>();
        // Assert
        Assert.NotNull(help);
        expected = detailsMap["help"];
        Assert.Equal(expected, help);

        // Act
        var localizedMessage = status.GetDetail<LocalizedMessage>();
        // Assert
        Assert.NotNull(localizedMessage);
        expected = detailsMap["localizedMessage"];
        Assert.Equal(expected, localizedMessage);
    }

    [Fact]
    public void GetStatusDetail_NotFound()
    {
        // Arrange - create a status with only a few details
        // The detailsMap contains all the Messages added to the status so
        // these can be used in the comparisions when then are retrieved later
        var detailsMap = new Dictionary<string, IMessage>();
        var status = CreatePartialStatus(detailsMap);

        // Act - try and retieve non-existent BadRequest from the status
        var badRequest = status.GetDetail<BadRequest>();
        // Assert
        Assert.Null(badRequest);
    }

    [Fact]
    public void UnpackDetailMessageTest()
    {
        // Arrange - create a status
        // The detailsMap contains all the Messages added to the status so
        // these can be used in the comparisions when then are retrieved later
        var detailsMap = new Dictionary<string, IMessage>();
        var status = CreateFullStatus(detailsMap);

        // foundSet will contain the messages found in the status so we can
        // check all those expected were present
        var foundSet = new HashSet<string>();

        // Act and Assert - iterate over all the messages in the status
        // and check they contain what is expected
        foreach (var msg in status.UnpackDetailMessages())
        {
            switch (msg)
            {
                case ErrorInfo errorInfo:
                    {
                        var expected = detailsMap["errorInfo"];
                        Assert.Equal(expected, errorInfo);
                        foundSet.Add("errorInfo");
                        break;
                    }

                case BadRequest badRequest:
                    {
                        var expected = detailsMap["badRequest"];
                        Assert.Equal(expected, badRequest);
                        foundSet.Add("badRequest");
                        break;
                    }

                case RetryInfo retryInfo:
                    {
                        var expected = detailsMap["retryInfo"];
                        Assert.Equal(expected, retryInfo);
                        foundSet.Add("retryInfo");
                        break;
                    }

                case DebugInfo debugInfo:
                    {
                        var expected = detailsMap["debugInfo"];
                        Assert.Equal(expected, debugInfo);
                        foundSet.Add("debugInfo");
                        break;
                    }

                case QuotaFailure quotaFailure:
                    {
                        var expected = detailsMap["quotaFailure"];
                        Assert.Equal(expected, quotaFailure);
                        foundSet.Add("quotaFailure");
                        break;
                    }

                case PreconditionFailure preconditionFailure:
                    {
                        var expected = detailsMap["preconditionFailure"];
                        Assert.Equal(expected, preconditionFailure);
                        foundSet.Add("preconditionFailure");
                        break;
                    }

                case RequestInfo requestInfo:
                    {
                        var expected = detailsMap["requestInfo"];
                        Assert.Equal(expected, requestInfo);
                        foundSet.Add("requestInfo");
                        break;
                    }

                case ResourceInfo resourceInfo:
                    {
                        var expected = detailsMap["resourceInfo"];
                        Assert.Equal(expected, resourceInfo);
                        foundSet.Add("resourceInfo");
                        break;
                    }

                case Help help:
                    {
                        var expected = detailsMap["help"];
                        Assert.Equal(expected, help);
                        foundSet.Add("help");
                        break;
                    }

                case LocalizedMessage localizedMessage:
                    {
                        var expected = detailsMap["localizedMessage"];
                        Assert.Equal(expected, localizedMessage);
                        foundSet.Add("localizedMessage");
                        break;
                    }
            }
        }

        // check everything was returned
        Assert.Equal(detailsMap.Count, foundSet.Count);

    }

    private static Google.Rpc.Status CreatePartialStatus(Dictionary<string, IMessage> detailsMap = null)
    {
        var retryInfo = new RetryInfo
        {
            RetryDelay = Duration.FromTimeSpan(new TimeSpan(0, 0, 5))
        };

        var debugInfo = new DebugInfo()
        {
            StackEntries = { "stack1", "stack2" },
            Detail = "detail"
        };

        // add details to a map for later checking
        if (detailsMap != null)
        {
            detailsMap.Clear();
            detailsMap.Add("retryInfo", retryInfo);
            detailsMap.Add("debugInfo", debugInfo);
        }

        var status = new Google.Rpc.Status()
        {
            Code = (int)Code.Unavailable,
            Message = "partial status",
            Details =
        {
            Any.Pack(retryInfo),
            Any.Pack(debugInfo),
        }
        };

        return status;
    }

    static Google.Rpc.Status CreateFullStatus(Dictionary<string, IMessage> detailsMap = null)
    {
        var errorInfo = new ErrorInfo()
        {
            Domain = "Rich Error Model Demo",
            Reason = "Full error requested in the demo",
            Metadata =
            {
                { "key1", "value1" },
                { "key2", "value2" }
            }
        };

        var badRequest = new BadRequest()
        {
            FieldViolations =
        {
            new BadRequest.Types.FieldViolation()
            {
                Field = "field", Description = "description"
            }
        }
        };

        var retryInfo = new RetryInfo
        {
            RetryDelay = Duration.FromTimeSpan(new TimeSpan(0, 0, 5))
        };

        var debugInfo = new DebugInfo()
        {
            StackEntries = { "stack1", "stack2" },
            Detail = "detail"
        };

        var quotaFailure = new QuotaFailure()
        {
            Violations =
        {
            new QuotaFailure.Types.Violation()
            {
                Description =  "Too much disk space used",
                Subject = "Disk23"
            }
        }
        };

        var preconditionFailure = new PreconditionFailure()
        {
            Violations =
        {
            new PreconditionFailure.Types.Violation()
            {
                Type = "type", Subject = "subject", Description = "description"
            }
        }
        };

        var requestInfo = new RequestInfo()
        {
            RequestId = "reqId",
            ServingData = "data"
        };

        var resourceInfo = new ResourceInfo()
        {
            ResourceType = "type",
            ResourceName = "name",
            Owner = "owner",
            Description = "description"
        };

        var help = new Help()
        {
            Links =
        {
            new Help.Types.Link() { Url="url1", Description="desc1" },
            new Help.Types.Link() { Url="url2", Description="desc2" },
        }
        };

        var localizedMessage = new LocalizedMessage()
        {
            Locale = "en-GB",
            Message = "Example localised error message"
        };

        // add details to a map for later checking
        if (detailsMap != null)
        {
            detailsMap.Clear();
            detailsMap.Add("badRequest", badRequest);
            detailsMap.Add("errorInfo", errorInfo);
            detailsMap.Add("retryInfo", retryInfo);
            detailsMap.Add("debugInfo", debugInfo);
            detailsMap.Add("quotaFailure", quotaFailure);
            detailsMap.Add("preconditionFailure", preconditionFailure);
            detailsMap.Add("requestInfo", requestInfo);
            detailsMap.Add("resourceInfo", resourceInfo);
            detailsMap.Add("help", help);
            detailsMap.Add("localizedMessage", localizedMessage);
        }

        var status = new Google.Rpc.Status()
        {
            Code = (int)Code.ResourceExhausted,
            Message = "Test",
            Details =
        {
            Any.Pack(badRequest),
            Any.Pack(errorInfo),
            Any.Pack(retryInfo),
            Any.Pack(debugInfo),
            Any.Pack(quotaFailure),
            Any.Pack(preconditionFailure),
            Any.Pack(requestInfo),
            Any.Pack(resourceInfo),
            Any.Pack(help),
            Any.Pack(localizedMessage)
        }
        };

        return status;
    }
}
