using Amazon;
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;
using Amazon.Runtime;
using System;
using System.Collections.Generic;
using SimpleEnergy_Log_Domain.Helpers;
using SimpleEnergy_Log_Application.Interfaces.Services;

namespace SimpleEnergy_Log_Application.Services
{
    public class CloudWatchService : ICloudWatchService
    {
        private readonly IAmazonCloudWatchLogs _logsClient;
        private readonly AWSConfiguration _awsConfiguration;

        public CloudWatchService(AWSConfiguration awsConfiguration)
        {
            _awsConfiguration = awsConfiguration;
            _logsClient = new AmazonCloudWatchLogsClient(
                    new BasicAWSCredentials(_awsConfiguration.AWSAccessKey, _awsConfiguration.AWSSecretKey),
                    new AmazonCloudWatchLogsConfig
                    {
                        RegionEndpoint = RegionEndpoint.SAEast1
                    }
                );
        }

        public async Task SendLog(string messagem, DateTime data)
        {
            var logEvent = new InputLogEvent
            {
                Message = messagem,
                Timestamp = data
            };

            var request = new PutLogEventsRequest
            {
                LogGroupName = _awsConfiguration.LogGroupName,
                LogStreamName = _awsConfiguration.LogStreamName,
                LogEvents = new List<InputLogEvent> { logEvent }
            };

            await _logsClient.PutLogEventsAsync(request);
        }
    }
}