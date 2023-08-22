using System.ComponentModel.DataAnnotations;
using FluentAssertions;

namespace PasswordKata.Tests {
    public class ValidatePasswordShould {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void Password_with_less_than_8_characters()
        {
            var result = ValidatePassword.Validate("abcd");

            result.Result.Should().Be(false);
            result.Errors.Should().Be("Password must be at least 8 characters");
        }

        [Test]
        public void Password_with_more_than_8_characters_and_two_numbers()
        {
            var  result = ValidatePassword.Validate("abcd1ert4");

            result.Result.Should().Be(true);
            result.Errors.Should().Be("");
        }

        [Test]
        public void Password_with_only_one_number()
        {
            var result = ValidatePassword.Validate("abcdefg1");

            result.Result.Should().Be(false);
            result.Errors.Should().Be("The password must contain at least 2 numbers");
        }
    }
}