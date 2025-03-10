﻿//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================

using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;

var aDotNetClient = new ADotNetClient();

var githubPipeline = new GithubPipeline
{
    Name = "GitHub Actions Pipeline",
    OnEvents = new Events
    {
        Push = new PushEvent
        {
            Branches = new string[] { "master" }
        },
        PullRequest = new PullRequestEvent
        {
            Branches = new string[] { "master" }
        }
    },
    Jobs = new Dictionary<string, Job>
    {
        {
            "build", new Job
            {
                RunsOn = BuildMachines.Windows2019,
                Steps = new List<GithubTask>
                {
                    new CheckoutTaskV2
                    {
                        Name = "Check out"
                    },
                    new SetupDotNetTaskV1
                    {
                        Name = "Setup .NET",
                        TargetDotNetVersion = new TargetDotNetVersion
                        {
                            DotNetVersion = "9.1.0",
                            //IncludePrerelease = true
                        }
                    },
                    new RestoreTask
                    {
                        Name = "Restore"
                    },
                    new DotNetBuildTask
                    {
                        Name = "Build"
                    },
                    new TestTask
                    {
                        Name = "Test"
                    }
                }
            }
        }
    }
};


var client = new ADotNetClient();

client.SerializeAndWriteToFile(
    adoPipeline: githubPipeline,
    path: "../../../../.github/workflows/dotnet.yml"
    );

//string buildScriptPath = "../../../../.github/workflows/dotnet.yml";
//string directoryPath = Path.GetDirectoryName(buildScriptPath);

//if (!Directory.Exists(directoryPath))
//{
//    Directory.CreateDirectory(directoryPath);
//}

//aDotNetClient.SerializeAndWriteToFile(githubPipeline, path: buildScriptPath);
