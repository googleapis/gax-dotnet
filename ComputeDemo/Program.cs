﻿// Copyright 2021 Google LLC
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

using Google.Cloud.Compute.V1;
using System;

namespace ComputeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Arguments: <project id> <zone>");
                return;
            }
            string projectId = args[0];
            string zone = args[1];
            var instancesClient = InstancesClient.Create();
            var response = instancesClient.List(projectId, zone);
            foreach (var instance in response.Items)
            {
                Console.WriteLine(instance.Name);
            }
        }
    }
}
