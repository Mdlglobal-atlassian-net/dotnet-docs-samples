﻿// Copyright (c) 2019 Google LLC.
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License. You may obtain a copy of
// the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
// WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
// License for the specific language governing permissions and limitations under
// the License.

using CommandLine;
using Google.Api.Gax.ResourceNames;
using Google.Cloud.AutoML.V1;
using Google.LongRunning;
using System;

namespace GoogleCloudSamples
{
    [Verb("create_model_language_sent_analysis", HelpText = "Create a model for language sentiment analysis")]
    public class LanguageSentimentAnalysisCreateModeloptions : CreateModelOptions
    {
    }

    class AutoMLLanguageSentimentAnalysisCreateModel
    {
        // [START automl_language_sentiment_analysis_create_model]
        /// <summary>
        /// Demonstrates using the AutoML client to create a model.
        /// </summary>
        /// <param name="projectId">GCP Project ID.</param>
        /// <param name="datasetId">the Id of the dataset.</param>
        public static object LanguageSentimentAnalysisCreateModel(string projectId = "YOUR-PROJECT-ID",
            string datasetId = "YOUR_DATASET_ID",
            string displayName = "YOUR_DATASET_NAME")
        {
            // Initialize the client that will be used to send requests. This client only needs to be created
            // once, and can be reused for multiple requests.
            AutoMlClient client = AutoMlClient.Create();

            // A resource that represents Google Cloud Platform location.
            string projectLocation = LocationName.Format(projectId, "us-central1");
            // Set model metadata.
            TextSentimentModelMetadata metadata = new TextSentimentModelMetadata
            {
            };
            Model model = new Model
            {
                DisplayName = displayName,
                DatasetId = datasetId,
                TextSentimentModelMetadata = metadata
            };

            // Create a model with the model metadata in the region.
            Operation<Model, OperationMetadata> response =
                client.CreateModel(projectLocation, model);
            // Don't wait for model creation to finish, as this can take several hours.
            // However, you can use the `name` of the operation to check the status of your model.

            Console.WriteLine($"Training operation name: {response.Name}");
            Console.WriteLine("Training started...");
            return 0;
        }
        // [END automl_language_sentiment_analysis_create_model]
        public static void RegisterCommands(VerbMap<object> verbMap)
        {
            verbMap.Add((LanguageSentimentAnalysisCreateModeloptions opts) =>
                AutoMLLanguageSentimentAnalysisCreateModel.LanguageSentimentAnalysisCreateModel(
                    opts.ProjectID,
                    opts.DatasetID,
                    opts.DisplayName));
        }
    }
}

