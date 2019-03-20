using System;
using ApiClientProject.Api;
using ApiClientProject.Client;
using ApiClientProject.Model;
using NUnit.Framework;
using Shouldly;
using Tests.Config;

namespace Tests
{
    [TestFixture]
    public class NegativeTests
    {
        private readonly Configuration _conf = TestsConfig.GetConfig().GetConfiguration();

        [Test]
        public void InvalidPositionTest()
        {
            var user = new CreationUserModel
            {
                DisplayName = Guid.NewGuid().ToString(),
                BirthDate = new DateTime(1993, 09, 07).ToString("yyyy-MM-dd"),
                PositionId = Guid.NewGuid().ToString(),
                WorkPeriodStartDate = DateTime.Now.Date.AddDays(-5).ToString("yyyy-MM-dd")
            };

            var error = Should.Throw<ApiException>(() => new UsersApi(_conf).PutUser(user));
            error.ShouldSatisfyAllConditions(
                () => error.ErrorCode.ShouldBe(400),
                () => error.Message.ShouldContain(
                    "{\"isSuccess\":false,\"errors\":[\"Position not found\"],\"result\":null}"
                )
            );
        }

        [Test]
        public void DeletionNotExistsUserTest()
        {
            var error = Should.Throw<ApiException>(() => new UsersApi(_conf).DeleteUser(Guid.NewGuid()));
            error.ShouldSatisfyAllConditions(
                () => error.ErrorCode.ShouldBe(400),
                () => error.Message.ShouldContain(
                    "{\"isSuccess\":false,\"errors\":[\"User not found\"],\"result\":null}"
                )
            );
        }

        [Test]
        public void MinMaxMisplacedValuesInFilterTest()
        {
            var error = Should.Throw<ApiException>(() => new UsersApi(_conf).GetFilteredUsers(new RequestUsersModel
            {
                Age = new MinMaxValueRequestModel(40, 30)
            }));
            error.ShouldSatisfyAllConditions(
                () => error.ErrorCode.ShouldBe(400),
                () => error.Message.ShouldContain("MaxValue should be greater or equals than MinValue"
                )
            );
        }
    }
}