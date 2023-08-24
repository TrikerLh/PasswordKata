using FluentAssertions;

namespace PasswordKata.Tests {
    public class ValidatePasswordShould {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void Password_with_less_than_8_characters()
        {
            var result = ValidatePassword.Validate("Ab!d15");

            result.Result.Should().Be(false);
            result.Errors.Should().Be("Password must be at least 8 characters");
        }

        [Test]
        public void Password_with_more_than_8_characters_and_two_numbers_and_a_capital_letter_and_special_character()
        {
            var  result = ValidatePassword.Validate("abCd1%ert4");

            result.Result.Should().Be(true);
            result.Errors.Should().Be("");
        }

        [Test]
        public void Password_with_only_one_number()
        {
            var result = ValidatePassword.Validate("abc!dRfg1");

            result.Result.Should().Be(false);
            result.Errors.Should().Be("The password must contain at least 2 numbers");
        }

        [Test]
        public void Password_with_less_than_8_characters_and_only_one_number()
        {
            var result = ValidatePassword.Validate("Abc1#");

            result.Result.Should().Be(false);
            result.Errors.Should()
                .Be("Password must be at least 8 characters\nThe password must contain at least 2 numbers");
        }

        [Test]
        public void Password_whit_out_capital_letter()
        {
            var result = ValidatePassword.Validate("sdf4sdf5ert$");

            result.Result.Should().Be(false);
            result.Errors.Should().Be("Password must contain at least one capital letter");
        }

        [Test]
        public void Password_whit_out_special_character()
        {
            var result = ValidatePassword.Validate("sdf4sdf5erT");

            result.Result.Should().Be(false);
            result.Errors.Should().Be("Password must contain at least one special character");
        }
    }
}