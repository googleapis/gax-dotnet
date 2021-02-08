// Copyright 2021 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Generated code. DO NOT EDIT!

namespace Google.Cloud.Compute.V1.Snippets
{
    using System.Threading.Tasks;

    /// <summary>Generated snippets.</summary>
    public sealed class GeneratedRegionSslCertificatesClientSnippets
    {
        /// <summary>Snippet for Delete</summary>
        public void DeleteRequestObject()
        {
            // Snippet: Delete(DeleteRegionSslCertificateRequest, CallSettings)
            // Create client
            RegionSslCertificatesClient regionSslCertificatesClient = RegionSslCertificatesClient.Create();
            // Initialize request argument(s)
            DeleteRegionSslCertificateRequest request = new DeleteRegionSslCertificateRequest
            {
                RequestId = "",
                SslCertificate = "",
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = regionSslCertificatesClient.Delete(request);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteRequestObjectAsync()
        {
            // Snippet: DeleteAsync(DeleteRegionSslCertificateRequest, CallSettings)
            // Additional: DeleteAsync(DeleteRegionSslCertificateRequest, CancellationToken)
            // Create client
            RegionSslCertificatesClient regionSslCertificatesClient = await RegionSslCertificatesClient.CreateAsync();
            // Initialize request argument(s)
            DeleteRegionSslCertificateRequest request = new DeleteRegionSslCertificateRequest
            {
                RequestId = "",
                SslCertificate = "",
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = await regionSslCertificatesClient.DeleteAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void Delete()
        {
            // Snippet: Delete(string, string, string, CallSettings)
            // Create client
            RegionSslCertificatesClient regionSslCertificatesClient = RegionSslCertificatesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string sslCertificate = "";
            // Make the request
            Operation response = regionSslCertificatesClient.Delete(project, region, sslCertificate);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteAsync()
        {
            // Snippet: DeleteAsync(string, string, string, CallSettings)
            // Additional: DeleteAsync(string, string, string, CancellationToken)
            // Create client
            RegionSslCertificatesClient regionSslCertificatesClient = await RegionSslCertificatesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string sslCertificate = "";
            // Make the request
            Operation response = await regionSslCertificatesClient.DeleteAsync(project, region, sslCertificate);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void GetRequestObject()
        {
            // Snippet: Get(GetRegionSslCertificateRequest, CallSettings)
            // Create client
            RegionSslCertificatesClient regionSslCertificatesClient = RegionSslCertificatesClient.Create();
            // Initialize request argument(s)
            GetRegionSslCertificateRequest request = new GetRegionSslCertificateRequest
            {
                SslCertificate = "",
                Region = "",
                Project = "",
            };
            // Make the request
            SslCertificate response = regionSslCertificatesClient.Get(request);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetRequestObjectAsync()
        {
            // Snippet: GetAsync(GetRegionSslCertificateRequest, CallSettings)
            // Additional: GetAsync(GetRegionSslCertificateRequest, CancellationToken)
            // Create client
            RegionSslCertificatesClient regionSslCertificatesClient = await RegionSslCertificatesClient.CreateAsync();
            // Initialize request argument(s)
            GetRegionSslCertificateRequest request = new GetRegionSslCertificateRequest
            {
                SslCertificate = "",
                Region = "",
                Project = "",
            };
            // Make the request
            SslCertificate response = await regionSslCertificatesClient.GetAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void Get()
        {
            // Snippet: Get(string, string, string, CallSettings)
            // Create client
            RegionSslCertificatesClient regionSslCertificatesClient = RegionSslCertificatesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string sslCertificate = "";
            // Make the request
            SslCertificate response = regionSslCertificatesClient.Get(project, region, sslCertificate);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetAsync()
        {
            // Snippet: GetAsync(string, string, string, CallSettings)
            // Additional: GetAsync(string, string, string, CancellationToken)
            // Create client
            RegionSslCertificatesClient regionSslCertificatesClient = await RegionSslCertificatesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string sslCertificate = "";
            // Make the request
            SslCertificate response = await regionSslCertificatesClient.GetAsync(project, region, sslCertificate);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void InsertRequestObject()
        {
            // Snippet: Insert(InsertRegionSslCertificateRequest, CallSettings)
            // Create client
            RegionSslCertificatesClient regionSslCertificatesClient = RegionSslCertificatesClient.Create();
            // Initialize request argument(s)
            InsertRegionSslCertificateRequest request = new InsertRegionSslCertificateRequest
            {
                RequestId = "",
                Region = "",
                SslCertificateResource = new SslCertificate(),
                Project = "",
            };
            // Make the request
            Operation response = regionSslCertificatesClient.Insert(request);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertRequestObjectAsync()
        {
            // Snippet: InsertAsync(InsertRegionSslCertificateRequest, CallSettings)
            // Additional: InsertAsync(InsertRegionSslCertificateRequest, CancellationToken)
            // Create client
            RegionSslCertificatesClient regionSslCertificatesClient = await RegionSslCertificatesClient.CreateAsync();
            // Initialize request argument(s)
            InsertRegionSslCertificateRequest request = new InsertRegionSslCertificateRequest
            {
                RequestId = "",
                Region = "",
                SslCertificateResource = new SslCertificate(),
                Project = "",
            };
            // Make the request
            Operation response = await regionSslCertificatesClient.InsertAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void Insert()
        {
            // Snippet: Insert(string, string, SslCertificate, CallSettings)
            // Create client
            RegionSslCertificatesClient regionSslCertificatesClient = RegionSslCertificatesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            SslCertificate sslCertificateResource = new SslCertificate();
            // Make the request
            Operation response = regionSslCertificatesClient.Insert(project, region, sslCertificateResource);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertAsync()
        {
            // Snippet: InsertAsync(string, string, SslCertificate, CallSettings)
            // Additional: InsertAsync(string, string, SslCertificate, CancellationToken)
            // Create client
            RegionSslCertificatesClient regionSslCertificatesClient = await RegionSslCertificatesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            SslCertificate sslCertificateResource = new SslCertificate();
            // Make the request
            Operation response = await regionSslCertificatesClient.InsertAsync(project, region, sslCertificateResource);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void ListRequestObject()
        {
            // Snippet: List(ListRegionSslCertificatesRequest, CallSettings)
            // Create client
            RegionSslCertificatesClient regionSslCertificatesClient = RegionSslCertificatesClient.Create();
            // Initialize request argument(s)
            ListRegionSslCertificatesRequest request = new ListRegionSslCertificatesRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                Region = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            SslCertificateList response = regionSslCertificatesClient.List(request);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListRequestObjectAsync()
        {
            // Snippet: ListAsync(ListRegionSslCertificatesRequest, CallSettings)
            // Additional: ListAsync(ListRegionSslCertificatesRequest, CancellationToken)
            // Create client
            RegionSslCertificatesClient regionSslCertificatesClient = await RegionSslCertificatesClient.CreateAsync();
            // Initialize request argument(s)
            ListRegionSslCertificatesRequest request = new ListRegionSslCertificatesRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                Region = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            SslCertificateList response = await regionSslCertificatesClient.ListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void List()
        {
            // Snippet: List(string, string, CallSettings)
            // Create client
            RegionSslCertificatesClient regionSslCertificatesClient = RegionSslCertificatesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            // Make the request
            SslCertificateList response = regionSslCertificatesClient.List(project, region);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListAsync()
        {
            // Snippet: ListAsync(string, string, CallSettings)
            // Additional: ListAsync(string, string, CancellationToken)
            // Create client
            RegionSslCertificatesClient regionSslCertificatesClient = await RegionSslCertificatesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            // Make the request
            SslCertificateList response = await regionSslCertificatesClient.ListAsync(project, region);
            // End snippet
        }
    }
}
