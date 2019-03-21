using System;
using System.Collections.Generic;
using System.Linq;
using ApiClientProject.Api;
using ApiClientProject.Client;
using ApiClientProject.Model;
using NUnit.Framework;
using Shouldly;
using Tests.Config;

// ReSharper disable PossibleInvalidOperationException

namespace Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class PositiveTests
    {
        private readonly Configuration _conf = TestsConfig.GetConfig().GetConfiguration();

        private int GetYearsFromToday(DateTime dateTime)
        {
            var today = DateTime.Today;
            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateTime.Year * 100 + dateTime.Month) * 100 + dateTime.Day;
            return (a - b) / 10000;
        }

        [Test]
        public void FilteringByAgeTest()
        {
            const int minAgeValue = 25;
            const int maxAgeValue = 30;
            var filteredUsers = new UsersApi(_conf).GetFilteredUsers(new RequestUsersModel
            {
                Age = new MinMaxValueRequestModel
                {
                    MinValue = minAgeValue,
                    MaxValue = maxAgeValue
                }
            }).Records;

            filteredUsers.ShouldSatisfyAllConditions(
                () => filteredUsers.Count.ShouldNotBe(0),
                () => filteredUsers.Select(x => x.BirthDate).All(x => GetYearsFromToday(x.Value) <= maxAgeValue)
                    .ShouldBeTrue(),
                () => filteredUsers.Select(x => x.BirthDate).All(x => GetYearsFromToday(x.Value) >= minAgeValue)
                    .ShouldBeTrue()
            );
        }

        [Test]
        public void FilteringByWorkPeriodExperienceTest()
        {
            const int minExperienceAge = 5;
            const int maxExperienceAge = 8;
            var filteredUsers = new UsersApi(_conf).GetFilteredUsers(new RequestUsersModel
            {
                WorkingExperience = new MinMaxValueRequestModel
                {
                    MinValue = minExperienceAge,
                    MaxValue = maxExperienceAge
                }
            }).Records;

            filteredUsers.ShouldSatisfyAllConditions(
                () => filteredUsers.Count.ShouldNotBe(0),
                () => filteredUsers.Select(x => x.WorkPeriodStartDate)
                    .All(x => GetYearsFromToday(x.Value) <= maxExperienceAge)
                    .ShouldBeTrue(),
                () => filteredUsers.Select(x => x.WorkPeriodStartDate)
                    .All(x => GetYearsFromToday(x.Value) >= minExperienceAge)
                    .ShouldBeTrue()
            );
        }

        [Test]
        public void FilteringByPositionsTest()
        {
            var positions = new List<string>
            {
                "General",
                "Doctor"
            };

            var needPositions = new PositionsApi(_conf).Get().Records.Where(x => positions.Contains(x.Name)).ToList();
            var filteredUsers = new UsersApi(_conf).GetFilteredUsers(new RequestUsersModel
            {
                Positions = needPositions.Select(x => x.Id).ToList()
            }).Records;

            filteredUsers.ShouldSatisfyAllConditions(
                () => filteredUsers.Count.ShouldNotBe(0),
                () => filteredUsers.Select(x => x.Position.Name).ShouldBeSubsetOf(needPositions.Select(x => x.Name)),
                () => filteredUsers.Select(x => x.Position.Id).ShouldBeSubsetOf(needPositions.Select(x => x.Id))
            );
        }

        [Test]
        public void MultipleFiltersTest()
        {
            const int minAgeValue = 25;
            const int maxAgeValue = 30;
            const int minExperienceAge = 4;
            const int maxExperienceAge = 19;
            var positions = new List<string>
            {
                "General",
                "Doctor"
            };

            var needPositions = new PositionsApi(_conf).Get().Records.Where(x => positions.Contains(x.Name)).ToList();
            var filteredUsers = new UsersApi(_conf).GetFilteredUsers(new RequestUsersModel
            {
                WorkingExperience = new MinMaxValueRequestModel
                {
                    MinValue = minExperienceAge,
                    MaxValue = maxExperienceAge
                },
                Age = new MinMaxValueRequestModel
                {
                    MinValue = minAgeValue,
                    MaxValue = maxAgeValue
                },
                Positions = needPositions.Select(x => x.Id).ToList()
            }).Records;

            filteredUsers.ShouldSatisfyAllConditions(
                () => filteredUsers.Count.ShouldNotBe(0),
                () => filteredUsers.Select(x => x.WorkPeriodStartDate)
                    .All(x => GetYearsFromToday(x.Value) <= maxExperienceAge)
                    .ShouldBeTrue(),
                () => filteredUsers.Select(x => x.WorkPeriodStartDate)
                    .All(x => GetYearsFromToday(x.Value) >= minExperienceAge)
                    .ShouldBeTrue(),
                () => filteredUsers.Select(x => x.WorkPeriodStartDate)
                    .All(x => GetYearsFromToday(x.Value) <= maxExperienceAge)
                    .ShouldBeTrue(),
                () => filteredUsers.Select(x => x.WorkPeriodStartDate)
                    .All(x => GetYearsFromToday(x.Value) >= minExperienceAge)
                    .ShouldBeTrue(),
                () => filteredUsers.Select(x => x.Position.Name).ShouldBeSubsetOf(needPositions.Select(x => x.Name)),
                () => filteredUsers.Select(x => x.Position.Id).ShouldBeSubsetOf(needPositions.Select(x => x.Id))
            );
        }

        [Test]
        public void UsersSortingTest()
        {
            var users = new UsersApi(_conf).GetFilteredUsers(new RequestUsersModel()).Records;
            var sortedList = users.OrderBy(x => x.WorkPeriodStartDate);
            users.ShouldBe(sortedList);
        }

        [Test]
        public void PaginationTest()
        {
            const int pageSize = 10;
            var page = 1;

            var allUsers = new UsersApi(_conf).GetFilteredUsers(new RequestUsersModel(
                1, 100500)).Records;

            var pageUser = new UsersApi(_conf).GetFilteredUsers(new RequestUsersModel
            {
                Page = page,
                PageSize = pageSize
            });

            pageUser.ShouldSatisfyAllConditions(
                () => pageUser.Records.Count.ShouldBe(pageSize),
                () => pageUser.Records.Select(x => x.DisplayName)
                    .ShouldBe(
                        allUsers
                            .Select(x => x.DisplayName)
                            .Skip((page - 1) * pageSize)
                            .Take(pageSize)
                    ),
                () => pageUser.CurrentPage.ShouldBe(page),
                () => pageUser.TotalPages.ShouldBe(allUsers.Count)
            );

            page++;
            pageUser = new UsersApi(_conf).GetFilteredUsers(new RequestUsersModel
            {
                Page = page,
                PageSize = pageSize
            });

            pageUser.ShouldSatisfyAllConditions(
                () => pageUser.Records.Count.ShouldBe(pageSize),
                () => pageUser.Records.Select(x => x.DisplayName)
                    .ShouldBe
                    (allUsers
                        .OrderBy(p => p.WorkPeriodStartDate)
                        .ThenBy(p => p.DisplayName)
                        .ThenBy(p => p.BirthDate).Select(x => x.DisplayName).Skip((page - 1) * pageSize)
                        .Take(pageSize)),
                () => pageUser.CurrentPage.ShouldBe(page),
                () => pageUser.TotalPages.ShouldBe(allUsers.Count)
            );
        }
    }
}