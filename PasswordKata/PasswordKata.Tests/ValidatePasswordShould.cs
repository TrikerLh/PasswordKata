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
        public void Password_with_more_than_8_characters()
        {
            var  result = ValidatePassword.Validate("123456789");

            result.Result.Should().Be(true);
            result.Errors.Should().Be("");
        }
    }
}