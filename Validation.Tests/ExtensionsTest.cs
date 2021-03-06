﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation;
using System.Linq;
using ExceptionAssert = MSTestExtensions.ExceptionAssert;

namespace Validation.Tests
{
    [TestClass]
    public class ExtensionsTest
    {
        [TestMethod]
        public void PassingValidToClass_IsNotNull_Passes()
        {
            Validate.Begin().IsNotNull<Object>(new Object(), "value").Check();
        }

        [TestMethod]
        public void PassingNullToClass_IsNotNull_Fails()
        {
            var valid = Validate.Begin().IsNotNull<Object>(null, "value");

            ExceptionAssert.Throws<ValidationException>(() => valid.Check());
        }

        [TestMethod]
        public void PassingNullNameToClass_IsNotNull_Throws()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => Validate.Begin().IsNotNull<Object>(new Object(), null));
        }

        [TestMethod]
        public void PassingEmptyNameToClass_IsNotNull_Throws()
        {
            ExceptionAssert.Throws<ArgumentException>(() => Validate.Begin().IsNotNull<Object>(new Object(), ""));
        }



        [TestMethod]
        public void PassingValidToStruct_IsNotNull_Passes()
        {
            Validate.Begin().IsNotNull((Int32?)5, "value").Check();
        }

        [TestMethod]
        public void PassingNullToStruct_IsNotNull_Fails()
        {
            var valid = Validate.Begin().IsNotNull<Int32>(null, "value");

            ExceptionAssert.Throws<ValidationException>(() => valid.Check());
        }

        [TestMethod]
        public void PassingNullNameToStruct_IsNotNull_Throws()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => Validate.Begin().IsNotNull((Int32?)5, null));
        }

        [TestMethod]
        public void PassingEmptyNameToStruct_IsNotNull_Throws()
        {
            ExceptionAssert.Throws<ArgumentException>(() => Validate.Begin().IsNotNull((Int32?)5, ""));
        }



        [TestMethod]
        public void PassingValidTo_IsNotNullOrEmpty_Passes()
        {
            Validate.Begin().IsNotNullOrEmpty("value", "value").Check();
        }

        [TestMethod]
        public void PassingNullTo_IsNotNullOrEmpty_Fails()
        {
            var valid = Validate.Begin().IsNotNullOrEmpty(null, "value");

            ExceptionAssert.Throws<ValidationException>(() => valid.Check());
        }

        [TestMethod]
        public void PassingEmptyTo_IsNotNullOrEmpty_Fails()
        {
            var valid = Validate.Begin().IsNotNullOrEmpty("", "value");

            ExceptionAssert.Throws<ValidationException>(() => valid.Check());
        }

        [TestMethod]
        public void PassingNullNameTo_IsNotNullOrEmpty_Throws()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => Validate.Begin().IsNotNullOrEmpty("value", null));
        }

        [TestMethod]
        public void PassingEmptyNameTo_IsNotNullOrEmpty_Throws()
        {
            ExceptionAssert.Throws<ArgumentException>(() => Validate.Begin().IsNotNullOrEmpty("value", ""));
        }



        [TestMethod]
        public void PassingValidToClass_IsWithinRange_Passes()
        {
            Validate.Begin().IsWithinRange(Tuple.Create(5), "value", Tuple.Create(0), Tuple.Create(10)).Check();
        }

        [TestMethod]
        public void PassingMinToClass_IsWithinRange_Passes()
        {
            Validate.Begin().IsWithinRange(Tuple.Create(0), "value", Tuple.Create(0), Tuple.Create(10)).Check();
        }

        [TestMethod]
        public void PassingMaxToClass_IsWithinRange_Passes()
        {
            Validate.Begin().IsWithinRange(Tuple.Create(10), "value", Tuple.Create(0), Tuple.Create(10)).Check();
        }

        [TestMethod]
        public void MinMaxValueSameToClass_IsWithinRange_Passes()
        {
            Validate.Begin().IsWithinRange(Tuple.Create(5), "value", Tuple.Create(5), Tuple.Create(5)).Check();
        }

        [TestMethod]
        public void PassingTooSmallToClass_IsWithinRange_Fails()
        {
            var valid = Validate.Begin().IsWithinRange(Tuple.Create(-1), "value", Tuple.Create(0), Tuple.Create(10));

            ExceptionAssert.Throws<ValidationException>(() => valid.Check());
        }

        [TestMethod]
        public void PassingTooLargeToClass_IsWithinRange_Fails()
        {
            var valid = Validate.Begin().IsWithinRange(Tuple.Create(11), "value", Tuple.Create(0), Tuple.Create(10));

            ExceptionAssert.Throws<ValidationException>(() => valid.Check());
        }

        [TestMethod]
        public void PassingNullToClass_IsWithinRange_Fails()
        {
            var valid = Validate.Begin().IsWithinRange(null, "value", Tuple.Create(0), Tuple.Create(10));

            ExceptionAssert.Throws<ValidationException>(() => valid.Check());
        }

        [TestMethod]
        public void PassingNullNameToClass_IsWithinRange_Throws()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().IsWithinRange(Tuple.Create(0), null, Tuple.Create(0), Tuple.Create(10)));
        }

        [TestMethod]
        public void PassingEmptyNameToClass_IsWithinRange_Throws()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().IsWithinRange(Tuple.Create(0), "", Tuple.Create(0), Tuple.Create(10)));
        }

        [TestMethod]
        public void PassingNullMinToClass_IsWithinRange_Throws()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().IsWithinRange(Tuple.Create(0), "value", null, Tuple.Create(10)));
        }

        [TestMethod]
        public void PassingNullMaxToClass_IsWithinRange_Throws()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().IsWithinRange(Tuple.Create(0), "value", Tuple.Create(0), null));
        }

        [TestMethod]
        public void PassingMinMaxBackwardsToClass_IsWithinRange_Throws()
        {
            ExceptionAssert.Throws<ArgumentException>(() => Validate.Begin().IsWithinRange(Tuple.Create(0), "value", Tuple.Create(10), Tuple.Create(0)));
        }



        [TestMethod]
        public void PassingValidToStruct_IsWithinRange_Passes()
        {
            Validate.Begin().IsWithinRange((Int32?)5, "value", 0, 10).Check();
        }

        [TestMethod]
        public void PassingMinToStruct_IsWithinRange_Passes()
        {
            Validate.Begin().IsWithinRange((Int32?)0, "value", 0, 10).Check();
        }

        [TestMethod]
        public void PassingMaxToStruct_IsWithinRange_Passes()
        {
            Validate.Begin().IsWithinRange((Int32?)10, "value", 0, 10).Check();
        }

        [TestMethod]
        public void MinMaxValueSameToStruct_IsWithinRange_Passes()
        {
            Validate.Begin().IsWithinRange((Int32?)5, "value", 5, 5).Check();
        }

        [TestMethod]
        public void PassingTooSmallToStruct_IsWithinRange_Fails()
        {
            var valid = Validate.Begin().IsWithinRange((Int32?)-1, "value", 0, 10);

            ExceptionAssert.Throws<ValidationException>(() => valid.Check());
        }

        [TestMethod]
        public void PassingTooLargeToStruct_IsWithinRange_Fails()
        {
            var valid = Validate.Begin().IsWithinRange((Int32?)11, "value", 0, 10);

            ExceptionAssert.Throws<ValidationException>(() => valid.Check());
        }

        [TestMethod]
        public void PassingNullToStruct_IsWithinRange_Fails()
        {
            var valid = Validate.Begin().IsWithinRange((Int32?)null, "value", 0, 10);

            ExceptionAssert.Throws<ValidationException>(() => valid.Check());
        }

        [TestMethod]
        public void PassingNullNameToStruct_IsWithinRange_Throws()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().IsWithinRange((Int32?)5, null, 0, 10));
        }

        [TestMethod]
        public void PassingEmptyNameToStruct_IsWithinRange_Throws()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().IsWithinRange((Int32?)5, "", 0, 10));
        }

        [TestMethod]
        public void PassingNullMinToStruct_IsWithinRange_Throws()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().IsWithinRange((Int32?)5, "value", null, 10));
        }

        [TestMethod]
        public void PassingNullMaxToStruct_IsWithinRange_Throws()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().IsWithinRange((Int32?)5, "value", 0, null));
        }

        [TestMethod]
        public void PassingMinMaxBackwardsToStruct_IsWithinRange_Throws()
        {
            ExceptionAssert.Throws<ArgumentException>(() => Validate.Begin().IsWithinRange((Int32?)5, "value", 10, 0));
        }



        [TestMethod]
        public void PassingValidDouble_IsNumeric_Passes()
        {
            Validate.Begin().IsNumeric("1.0", "value").Check();
        }

        [TestMethod]
        public void PassingValidInt_IsNumeric_Passes()
        {
            Validate.Begin().IsNumeric("1000", "value").Check();
        }

        [TestMethod]
        public void PassingWords_IsNumeric_Fails()
        {
            var valid = Validate.Begin().IsNumeric("value", "value");

            ExceptionAssert.Throws<ValidationException>(() => valid.Check());
        }

        [TestMethod]
        public void PassingNull_IsNumeric_Fails()
        {
            var valid = Validate.Begin().IsNumeric(null, "value");

            ExceptionAssert.Throws<ValidationException>(() => valid.Check());
        }

        [TestMethod]
        public void PassingEmpty_IsNumeric_Fails()
        {
            var valid = Validate.Begin().IsNumeric("", "value");

            ExceptionAssert.Throws<ValidationException>(() => valid.Check());
        }

        [TestMethod]
        public void PassingNullName_IsNumeric_Throws()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().IsNumeric("123", null));
        }

        [TestMethod]
        public void PassingEmptyName_IsNumeric_Throws()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().IsNumeric("123", ""));
        }



        [TestMethod]
        public void PassingTrue_IsTrue_Passes()
        {
            Validate.Begin().IsTrue(true, "value").Check();
        }

        [TestMethod]
        public void PassingFalse_IsTrue_Fails()
        {
            var valid = Validate.Begin().IsTrue(false, "value");

            ExceptionAssert.Throws<ValidationException>(() => valid.Check());
        }

        [TestMethod]
        public void PassingNullName_IsTrue_Throws()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().IsTrue(true, null));
        }

        [TestMethod]
        public void PassingEmptyName_IsTrue_Throws()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().IsTrue(true, ""));
        }



        [TestMethod]
        public void PassingFalse_IsFalse_Passes()
        {
            Validate.Begin().IsFalse(false, "value").Check();
        }

        [TestMethod]
        public void PassingTrhe_IsFalse_Fails()
        {
            var valid = Validate.Begin().IsFalse(true, "value");

            ExceptionAssert.Throws<ValidationException>(() => valid.Check());
        }

        [TestMethod]
        public void PassingNullName_IsFalse_Throws()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().IsFalse(false, null));
        }

        [TestMethod]
        public void PassingEmptyName_IsFalse_Throws()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().IsFalse(false, ""));
        }



        [TestMethod]
        public void PassingValidClass_AreEqual_Passes()
        {
            Validate.Begin().AreEqual(Tuple.Create(5), Tuple.Create(5), "expectedValue", "actualValue").Check();
        }

        [TestMethod]
        public void PassingValidValue_AreEqual_Passes()
        {
            Validate.Begin().AreEqual(5, 5, "expectedValue", "expectedValue").Check();
        }

        [TestMethod]
        public void PassingUnmatchedClass_AreEqual_Fails()
        {
            var valid = Validate.Begin().AreEqual(Tuple.Create(5), Tuple.Create(3), "expectedValue", "actualValue");

            ExceptionAssert.Throws<ValidationException>(() => valid.Check());
        }

        [TestMethod]
        public void PassingUnmatchedValue_AreEqual_Fails()
        {
            var valid = Validate.Begin().AreEqual(5, 3, "expectedValue", "actualValue");

            ExceptionAssert.Throws<ValidationException>(() => valid.Check());
        }

        [TestMethod]
        public void PassingNullExName_AreEqual_Throws()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().AreEqual(5, 5, null, "actualValue"));
        }

        [TestMethod]
        public void PassingEmptyExName_AreEqual_Throws()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().AreEqual(5, 5, "", "actualValue"));
        }

        [TestMethod]
        public void PassingNullActName_AreEqual_Throws()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().AreEqual(5, 5, "expectedValue", null));
        }

        [TestMethod]
        public void PassingEmptyActName_AreEqual_Throws()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().AreEqual(5, 5, "expectedValue", ""));
        }



        [TestMethod]
        public void PassingFalse_ValidateWhen_Skips()
        {
            Validate.Begin().ValidateWhen(false).IsNotNull<Object>(null, "value").Check();
        }

        [TestMethod]
        public void PassingTrue_ValidateWhen_Checks()
        {
            ExceptionAssert.Throws<ValidationException>(() => Validate.Begin().ValidateWhen(true).IsNotNull<Object>(null, "value").Check());
        }



        [TestMethod]
        public void NullLength_Null_Matches()
        {
            var result = ((string[])null).NullLength();

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void NullLength_NotNull_Matches()
        {
            var result = (new string[] { }).NullLength();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void NullLength_NullWithZero_Matches()
        {
            var result = ((string[])null).NullLength(zeroBase: true);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void NullLength_NullWithoutZero_Matches()
        {
            var result = ((string[])null).NullLength(zeroBase: false);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void NullLength_NotNullWithZero_Matches()
        {
            var result = (new string[] {}).NullLength(zeroBase: true);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void NullLength_NotNullWithoutZero_Matches()
        {
            var result = (new string[] {}).NullLength(zeroBase: false);

            Assert.AreEqual(0, result);
        }
    }
}
