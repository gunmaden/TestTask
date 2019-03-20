using System;
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
    [Parallelizable(ParallelScope.None)]
    public class PositiveNonParallelledTests
    {
        private readonly Configuration _conf = TestsConfig.GetConfig().GetConfiguration();

        [Test]
        public void UserCreationTest()
        {
            const string position = "General";

            var needPosition = new PositionsApi(_conf).Get().Records.Find(x => x.Name == position);

            var user = new CreationUserModel
            {
                DisplayName = Guid.NewGuid().ToString(),
                BirthDate = new DateTime(1993, 09, 07).ToString("yyyy-MM-dd"),
                PositionId = needPosition.Id.ToString(),
                WorkPeriodStartDate = DateTime.Now.Date.AddDays(-5).ToString("yyyy-MM-dd")
            };

            var responseModelUser = new UsersApi(_conf).PutUser(user);

            responseModelUser.ShouldSatisfyAllConditions(
                () => responseModelUser.IsSuccess.GetValueOrDefault().ShouldBeTrue(),
                () => responseModelUser.Errors.ShouldBeNull(),
                () => responseModelUser.Result.ShouldBeOfType(typeof(User))
            );

            new UsersApi(_conf).GetFilteredUsers(new RequestUsersModel()).Records.ShouldContain(x =>
                x.DisplayName == user.DisplayName && x.Id == responseModelUser.Result.Id);
        }

        [Test]
        public void UserDeletionTest()
        {
            const string position = "General";

            var needPosition = new PositionsApi(_conf).Get().Records.Find(x => x.Name == position);

            var user = new CreationUserModel
            {
                DisplayName = Guid.NewGuid().ToString(),
                BirthDate = new DateTime(1993, 09, 07).ToString("yyyy-MM-dd"),
                PositionId = needPosition.Id.ToString(),
                WorkPeriodStartDate = DateTime.Now.Date.AddDays(-5).ToString("yyyy-MM-dd")
            };
            var responseModelUser = new UsersApi(_conf).PutUser(user);

            new UsersApi(_conf).DeleteUser(responseModelUser.Result.Id);
        }
    }
}