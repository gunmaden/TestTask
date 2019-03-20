using System;
using NBomber.CSharp;
using NUnit.Framework;
using PerfTests.Config;
using PerfTests.Scenarios;

namespace PerfTests
{
    [TestFixture]
    public class LoadTests
    {
        private readonly ConfigModel _config = TestsConfig.GetConfig();

        [Test]
        public void LoadTestExample()
        {
            var filterScenario =
                UsersScenarios
                    .BuildUsersFilterScenario(_config.GetConfiguration())
                    .WithConcurrentCopies(_config.SessionsCount)
                    .WithWarmUpDuration(TimeSpan.FromSeconds(_config.WarmUpDurationInSeconds))
                    .WithDuration(TimeSpan.FromSeconds(_config.TestingDurationInSeconds));

            var createUserScenario =
                UsersScenarios
                    .BuildUserCreationScenario(_config.GetConfiguration())
                    .WithConcurrentCopies(_config.SessionsCount)
                    .WithWarmUpDuration(TimeSpan.FromSeconds(_config.WarmUpDurationInSeconds))
                    .WithDuration(TimeSpan.FromSeconds(_config.TestingDurationInSeconds));

            NBomberRunner.RegisterScenarios(
                filterScenario,
                createUserScenario).RunTest();
        }
    }
}