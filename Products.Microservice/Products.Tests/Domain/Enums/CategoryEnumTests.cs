using FluentAssertions;
using Products.Domain.Enums;

namespace Products.Tests.Domain.Enums
{
    public class CategoryEnumTests
    {
        [Fact]
        public void CategoryEnum_ShouldHaveFourValues()
        {
            var values = Enum.GetValues(typeof(CategoryEnum));

            values.Length.Should().Be(4);
        }

        [Fact]
        public void CategoryEnum_SANDWICH_ShouldHaveCorrectValue()
        {
            var value = (int)CategoryEnum.SANDWICH;

            value.Should().Be(1);
        }

        [Fact]
        public void CategoryEnum_SIDE_ShouldHaveCorrectValue()
        {
            var value = (int)CategoryEnum.SIDE;

            value.Should().Be(2);
        }

        [Fact]
        public void CategoryEnum_DRINK_ShouldHaveCorrectValue()
        {
            var value = (int)CategoryEnum.DRINK;

            value.Should().Be(3);
        }

        [Fact]
        public void CategoryEnum_DESSERT_ShouldHaveCorrectValue()
        {
            var value = (int)CategoryEnum.DESSERT;

            value.Should().Be(4);
        }

        [Fact]
        public void CategoryEnum_AllValuesShouldBeUnique()
        {
            var values = Enum.GetValues(typeof(CategoryEnum))
                .Cast<int>()
                .ToList();

            values.Should().OnlyHaveUniqueItems();
        }

        [Fact]
        public void CategoryEnum_ShouldContainSANDWICH()
        {
            var contains = Enum.IsDefined(typeof(CategoryEnum), CategoryEnum.SANDWICH);

            contains.Should().BeTrue();
        }

        [Fact]
        public void CategoryEnum_ShouldContainSIDE()
        {
            var contains = Enum.IsDefined(typeof(CategoryEnum), CategoryEnum.SIDE);

            contains.Should().BeTrue();
        }

        [Fact]
        public void CategoryEnum_ShouldContainDRINK()
        {
            var contains = Enum.IsDefined(typeof(CategoryEnum), CategoryEnum.DRINK);

            contains.Should().BeTrue();
        }

        [Fact]
        public void CategoryEnum_ShouldContainDESSERT()
        {
            var contains = Enum.IsDefined(typeof(CategoryEnum), CategoryEnum.DESSERT);

            contains.Should().BeTrue();
        }

        [Fact]
        public void CategoryEnum_GetNames_ShouldReturnAllNames()
        {
            var names = Enum.GetNames(typeof(CategoryEnum));

            names.Should().Contain("SANDWICH");
            names.Should().Contain("SIDE");
            names.Should().Contain("DRINK");
            names.Should().Contain("DESSERT");
            names.Should().HaveCount(4);
        }

        [Fact]
        public void CategoryEnum_GetValues_ShouldReturnAllValues()
        {
            var values = Enum.GetValues(typeof(CategoryEnum)).Cast<CategoryEnum>().ToList();

            values.Should().Contain(CategoryEnum.SANDWICH);
            values.Should().Contain(CategoryEnum.SIDE);
            values.Should().Contain(CategoryEnum.DRINK);
            values.Should().Contain(CategoryEnum.DESSERT);
        }

        [Fact]
        public void CategoryEnum_ParseFromString_SANDWICH_ShouldWork()
        {
            var parsed = Enum.Parse<CategoryEnum>("SANDWICH");

            parsed.Should().Be(CategoryEnum.SANDWICH);
        }

        [Fact]
        public void CategoryEnum_ParseFromString_SIDE_ShouldWork()
        {
            var parsed = Enum.Parse<CategoryEnum>("SIDE");

            parsed.Should().Be(CategoryEnum.SIDE);
        }

        [Fact]
        public void CategoryEnum_ParseFromString_DRINK_ShouldWork()
        {
            var parsed = Enum.Parse<CategoryEnum>("DRINK");

            parsed.Should().Be(CategoryEnum.DRINK);
        }

        [Fact]
        public void CategoryEnum_ParseFromString_DESSERT_ShouldWork()
        {
            var parsed = Enum.Parse<CategoryEnum>("DESSERT");

            parsed.Should().Be(CategoryEnum.DESSERT);
        }

        [Fact]
        public void CategoryEnum_ParseFromInt_1_ShouldReturnSANDWICH()
        {
            var category = (CategoryEnum)1;

            category.Should().Be(CategoryEnum.SANDWICH);
        }

        [Fact]
        public void CategoryEnum_ParseFromInt_2_ShouldReturnSIDE()
        {
            var category = (CategoryEnum)2;

            category.Should().Be(CategoryEnum.SIDE);
        }

        [Fact]
        public void CategoryEnum_ParseFromInt_3_ShouldReturnDRINK()
        {
            var category = (CategoryEnum)3;

            category.Should().Be(CategoryEnum.DRINK);
        }

        [Fact]
        public void CategoryEnum_ParseFromInt_4_ShouldReturnDESSERT()
        {
            var category = (CategoryEnum)4;

            category.Should().Be(CategoryEnum.DESSERT);
        }

        [Fact]
        public void CategoryEnum_ToString_SANDWICH_ShouldReturnCorrectString()
        {
            var result = CategoryEnum.SANDWICH.ToString();

            result.Should().Be("SANDWICH");
        }

        [Fact]
        public void CategoryEnum_ToString_SIDE_ShouldReturnCorrectString()
        {
            var result = CategoryEnum.SIDE.ToString();

            result.Should().Be("SIDE");
        }

        [Fact]
        public void CategoryEnum_ToString_DRINK_ShouldReturnCorrectString()
        {
            var result = CategoryEnum.DRINK.ToString();

            result.Should().Be("DRINK");
        }

        [Fact]
        public void CategoryEnum_ToString_DESSERT_ShouldReturnCorrectString()
        {
            var result = CategoryEnum.DESSERT.ToString();

            result.Should().Be("DESSERT");
        }

        [Fact]
        public void CategoryEnum_TryParse_ValidName_ShouldReturnTrue()
        {
            var success = Enum.TryParse<CategoryEnum>("SANDWICH", out var result);

            success.Should().BeTrue();
            result.Should().Be(CategoryEnum.SANDWICH);
        }

        [Fact]
        public void CategoryEnum_TryParse_InvalidName_ShouldReturnFalse()
        {
            var success = Enum.TryParse<CategoryEnum>("INVALID", out var result);

            success.Should().BeFalse();
            result.Should().Be(default(CategoryEnum));
        }

        [Fact]
        public void CategoryEnum_TryParse_CaseInsensitive_ShouldWork()
        {
            var success = Enum.TryParse<CategoryEnum>("sandwich", true, out var result);

            success.Should().BeTrue();
            result.Should().Be(CategoryEnum.SANDWICH);
        }

        [Fact]
        public void CategoryEnum_TryParse_CaseSensitive_LowerCase_ShouldFail()
        {
            var success = Enum.TryParse<CategoryEnum>("sandwich", false, out var result);

            success.Should().BeFalse();
        }

        [Fact]
        public void CategoryEnum_IsDefined_WithValidValue_ShouldReturnTrue()
        {
            var isDefined = Enum.IsDefined(typeof(CategoryEnum), 1);

            isDefined.Should().BeTrue();
        }

        [Fact]
        public void CategoryEnum_IsDefined_WithInvalidValue_ShouldReturnFalse()
        {
            var isDefined = Enum.IsDefined(typeof(CategoryEnum), 99);

            isDefined.Should().BeFalse();
        }

        [Fact]
        public void CategoryEnum_IsDefined_WithZero_ShouldReturnFalse()
        {
            var isDefined = Enum.IsDefined(typeof(CategoryEnum), 0);

            isDefined.Should().BeFalse();
        }

        [Fact]
        public void CategoryEnum_ComparisonOperators_ShouldWork()
        {
            (CategoryEnum.SANDWICH < CategoryEnum.SIDE).Should().BeTrue();
            (CategoryEnum.SIDE < CategoryEnum.DRINK).Should().BeTrue();
            (CategoryEnum.DRINK < CategoryEnum.DESSERT).Should().BeTrue();
            (CategoryEnum.DESSERT > CategoryEnum.SANDWICH).Should().BeTrue();
        }

        [Fact]
        public void CategoryEnum_EqualityComparison_ShouldWork()
        {
            var category1 = CategoryEnum.SANDWICH;
            var category2 = CategoryEnum.SANDWICH;
            var category3 = CategoryEnum.SIDE;

            category1.Should().Be(category2);
            category1.Should().NotBe(category3);
            (category1 == category2).Should().BeTrue();
            (category1 == category3).Should().BeFalse();
        }

        [Fact]
        public void CategoryEnum_GetHashCode_SameValues_ShouldBeEqual()
        {
            var category1 = CategoryEnum.DRINK;
            var category2 = CategoryEnum.DRINK;

            var hash1 = category1.GetHashCode();
            var hash2 = category2.GetHashCode();

            hash1.Should().Be(hash2);
        }

        [Fact]
        public void CategoryEnum_GetHashCode_DifferentValues_ShouldBeDifferent()
        {
            var category1 = CategoryEnum.SANDWICH;
            var category2 = CategoryEnum.DESSERT;

            var hash1 = category1.GetHashCode();
            var hash2 = category2.GetHashCode();

            hash1.Should().NotBe(hash2);
        }

        [Theory]
        [InlineData(CategoryEnum.SANDWICH, 1)]
        [InlineData(CategoryEnum.SIDE, 2)]
        [InlineData(CategoryEnum.DRINK, 3)]
        [InlineData(CategoryEnum.DESSERT, 4)]
        public void CategoryEnum_CastToInt_ShouldReturnCorrectValue(CategoryEnum category, int expectedValue)
        {
            var value = (int)category;

            value.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(1, CategoryEnum.SANDWICH)]
        [InlineData(2, CategoryEnum.SIDE)]
        [InlineData(3, CategoryEnum.DRINK)]
        [InlineData(4, CategoryEnum.DESSERT)]
        public void CategoryEnum_CastFromInt_ShouldReturnCorrectCategory(int value, CategoryEnum expectedCategory)
        {
            var category = (CategoryEnum)value;

            category.Should().Be(expectedCategory);
        }

        [Theory]
        [InlineData("SANDWICH")]
        [InlineData("SIDE")]
        [InlineData("DRINK")]
        [InlineData("DESSERT")]
        public void CategoryEnum_ParseFromString_AllValues_ShouldNotThrow(string categoryName)
        {
            var act = () => Enum.Parse<CategoryEnum>(categoryName);

            act.Should().NotThrow();
        }

        [Fact]
        public void CategoryEnum_ParseFromString_InvalidValue_ShouldThrow()
        {
            var act = () => Enum.Parse<CategoryEnum>("INVALID_CATEGORY");

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CategoryEnum_GetUnderlyingType_ShouldBeInt32()
        {
            var underlyingType = Enum.GetUnderlyingType(typeof(CategoryEnum));

            underlyingType.Should().Be(typeof(int));
        }

        [Fact]
        public void CategoryEnum_CanBeUsedInSwitchStatement()
        {
            var category = CategoryEnum.SANDWICH;
            string result = string.Empty;

            switch (category)
            {
                case CategoryEnum.SANDWICH:
                    result = "Lanche";
                    break;
                case CategoryEnum.SIDE:
                    result = "Acompanhamento";
                    break;
                case CategoryEnum.DRINK:
                    result = "Bebida";
                    break;
                case CategoryEnum.DESSERT:
                    result = "Sobremesa";
                    break;
            }

            result.Should().Be("Lanche");
        }

        [Fact]
        public void CategoryEnum_CanBeUsedInDictionary()
        {
            var dictionary = new Dictionary<CategoryEnum, string>
            {
                { CategoryEnum.SANDWICH, "Lanche" },
                { CategoryEnum.SIDE, "Acompanhamento" },
                { CategoryEnum.DRINK, "Bebida" },
                { CategoryEnum.DESSERT, "Sobremesa" }
            };

            dictionary[CategoryEnum.SANDWICH].Should().Be("Lanche");
            dictionary[CategoryEnum.SIDE].Should().Be("Acompanhamento");
            dictionary[CategoryEnum.DRINK].Should().Be("Bebida");
            dictionary[CategoryEnum.DESSERT].Should().Be("Sobremesa");
        }

        [Fact]
        public void CategoryEnum_CanBeUsedInList()
        {
            var list = new List<CategoryEnum>
            {
                CategoryEnum.SANDWICH,
                CategoryEnum.SIDE,
                CategoryEnum.DRINK,
                CategoryEnum.DESSERT
            };

            list.Should().HaveCount(4);
            list.Should().Contain(CategoryEnum.SANDWICH);
            list.Should().ContainInOrder(
                CategoryEnum.SANDWICH,
                CategoryEnum.SIDE,
                CategoryEnum.DRINK,
                CategoryEnum.DESSERT
            );
        }

        [Fact]
        public void CategoryEnum_DefaultValue_ShouldBeZero()
        {
            var defaultValue = default(CategoryEnum);

            ((int)defaultValue).Should().Be(0);
        }

        [Fact]
        public void CategoryEnum_MinValue_ShouldBeSANDWICH()
        {
            var minValue = Enum.GetValues(typeof(CategoryEnum))
                .Cast<CategoryEnum>()
                .Min();

            minValue.Should().Be(CategoryEnum.SANDWICH);
            ((int)minValue).Should().Be(1);
        }

        [Fact]
        public void CategoryEnum_MaxValue_ShouldBeDESSERT()
        {
            var maxValue = Enum.GetValues(typeof(CategoryEnum))
                .Cast<CategoryEnum>()
                .Max();

            maxValue.Should().Be(CategoryEnum.DESSERT);
            ((int)maxValue).Should().Be(4);
        }
    }
}