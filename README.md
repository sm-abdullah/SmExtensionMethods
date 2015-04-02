SmExtensionMethods
========================

C# extension methods Utility <br>
it contains bunch of nice utlity methods
<h2> How to use ? </h2>

            // try to convert '1234' into int 
            int i = "1234".toInt() ?? 0;
            Assert.AreEqual(i, 1234);
            i = "a1234".toInt() ?? 0;
            Assert.AreEqual(i, 0);
            // try to convert '0123' to decimal
            decimal d = "0123".toDecimal() ?? 0;
            Assert.AreEqual(d, 0123);<br>
            d = "0a123".toDecimal() ?? 1;
            Assert.AreEqual(d, 1);
