using System;
using System.Linq;
using ApiClientProject.Api;
using ApiClientProject.Client;
using ApiClientProject.Model;
using NBomber.Contracts;
using NBomber.CSharp;

namespace PerfTests.Scenarios
{
    public class UsersScenarios
    {
        public static Scenario BuildUsersFilterScenario(Configuration conf)
        {
            var positions = new PositionsApi(conf).Get().Records;
            var getFilteredUsersStep = Step.CreateAction("Get filtered Users", ConnectionPool.None, async x =>
            {
                var positionsCount = new Random().Next(1, 5);
                var positionsToPut = positions.GetRange(0, positionsCount);
                var minAgeFilter = new Random().Next(20, 60);
                var maxAgeFilter = new Random().Next(minAgeFilter, 60);
                var minExpFilter = new Random().Next(1, 20);
                var maxExpFilter = new Random().Next(minExpFilter, 20);
                var filteredUsers = await new UsersApi(conf).GetFilteredUsersAsyncWithHttpInfo(new RequestUsersModel
                {
                    WorkingExperience = new MinMaxValueRequestModel
                    {
                        MinValue = minExpFilter,
                        MaxValue = maxExpFilter
                    },
                    Age = new MinMaxValueRequestModel
                    {
                        MinValue = minAgeFilter,
                        MaxValue = maxAgeFilter
                    },
                    Positions = positionsToPut.Select(i => i.Id).ToList()
                });

                return filteredUsers.StatusCode == 200 ? Response.Ok() : Response.Fail();
            });

            return ScenarioBuilder.CreateScenario("Get Filtered Users Scenario", getFilteredUsersStep);
        }

        public static Scenario BuildUserCreationScenario(Configuration conf)
        {
            var positions = new PositionsApi(conf).Get().Records;

            var getFilteredUsersStep = Step.CreateAction("Create user", ConnectionPool.None, async x =>
            {
                var position = new Random().Next(1, positions.Count - 1);
                var positionToPut = positions.ElementAt(position);

                var age = new Random().Next(20, 60);
                var exp = new Random().Next(1, 20);

                var response = await new UsersApi(conf).PutUserAsyncWithHttpInfo(new CreationUserModel
                {
                    DisplayName = Guid.NewGuid().ToString(),
                    BirthDate = DateTime.Now.AddYears(-age).ToString("yyyy-MM-dd"),
                    WorkPeriodStartDate = DateTime.Now.AddYears(-exp).ToString("yyyy-MM-dd"),
                    PositionId = positionToPut.Id.ToString()
                });

                return response.Data.IsSuccess == true ? Response.Ok() : Response.Fail();
            });

            return ScenarioBuilder.CreateScenario("Create User Scenario", getFilteredUsersStep);
        }
    }
}