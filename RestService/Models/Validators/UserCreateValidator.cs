using System;
using System.Globalization;
using FluentValidation;
using Models.RequestModels;

namespace Models.Validators
{
    public class UserCreateValidator : AbstractValidator<CreationUserModel>
    {
        public UserCreateValidator()
        {
            RuleFor(x => x.BirthDate)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .Must(BeAValidDate).WithMessage("BirthDate must be in format yyyy-MM-dd")
                .DependentRules(() =>
                {
                    RuleFor(x => x.GetBirthDateTime()).InclusiveBetween(
                            new DateTime(1960, 01, 01),
                            new DateTime(2000, 01, 01))
                        .WithMessage($"BirthDate must be between 2000-01-01 and {DateTime.Now:yyyy-MM-dd}");
                });

            RuleFor(x => x.WorkPeriodStartDate)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .Must(BeAValidDate).WithMessage("WorkPeriodStartDate must be in format yyyy-MM-dd")
                .DependentRules(() =>
                {
                    RuleFor(x => x.GetWorkPeriodStartDateTime()).InclusiveBetween(
                            new DateTime(2000, 01, 01),
                            DateTime.Now)
                        .WithMessage($"WorkPeriodStartDate must be between 2000-01-01 and {DateTime.Now:yyyy-MM-dd}");
                });
        }

        private bool BeAValidDate(string dateTime)
        {
            return DateTime.TryParseExact(dateTime,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _);
        }
    }
}