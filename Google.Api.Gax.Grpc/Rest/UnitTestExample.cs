// Shows how I acceptance-test server streaming
// Throw Away before making PR non-draft

//[Fact]
//public void TestExpand()
//{
//    var builder = new Google.Showcase.V1Beta1.EchoClientBuilder
//    {
//        Endpoint = "http://localhost:7469",
//        ChannelCredentials = Grpc.Core.ChannelCredentials.Insecure
//    };
//    var client = builder.Build();
//    string content = "Sphinx of black quartz, {}]}}}}\\}}}[]]]]judge my vow.";

//    DateTime reqStart = DateTime.UtcNow;
//    var response = client.Expand(new ExpandRequest { Content = content });
//    var responseStream = response.GetResponseStream();

//    DateTime? firstResultAt = null;
//    DateTime lastResultAt = DateTime.UtcNow;
//    var resp = new List<string>();
//    while (true)
//    {
//        bool endOfStream = !responseStream.MoveNextAsync().ConfigureAwait(false).GetAwaiter().GetResult();
//        if (endOfStream)
//        {
//            break;
//        }

//        resp.Add(responseStream.Current.Content);
//        firstResultAt ??= DateTime.UtcNow;
//        lastResultAt = DateTime.UtcNow;
//    }

//    var sb = resp.Aggregate(new StringBuilder(), (stringBuilder, s1) => stringBuilder.AppendFormat("{0} ", s1));
//    var s = sb.ToString();

//    // I've modified my local copy of the showcase-server to
//    // return the input 1000 times followed by 30 seconds of sleep,
//    // return the input 1000 times followed by 30 seconds of sleep,
//    // return the input 1000 times

//    Assert.Contains(content, s);
//    Assert.True((lastResultAt - firstResultAt.Value).TotalSeconds > 50);
//    Assert.True((lastResultAt - reqStart).TotalSeconds > 59);
//    Assert.True(resp.Count == 3 * 1000 * 7);
//}
