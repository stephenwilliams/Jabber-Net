/* --------------------------------------------------------------------------
 * Copyrights
 *
 * Portions created by or assigned to Cursive Systems, Inc. are
 * Copyright (c) 2002-2008 Cursive Systems, Inc.  All Rights Reserved.  Contact
 * information for Cursive Systems, Inc. is available at
 * http://www.cursive.net/.
 *
 * License
 *
 * Jabber-Net is licensed under the LGPL.
 * See licenses/Jabber-Net_LGPLv3.txt for details.
 * --------------------------------------------------------------------------*/
#if !NO_STRINGPREP

using JabberNet.stringprep;
using JabberNet.stringprep.steps;
using NUnit.Framework;

namespace JabberNet.Test.stringprep
{
    [TestFixture]
    public class TestResourceprep
    {
        private static System.Text.Encoding ENC = System.Text.Encoding.UTF8;

        private Profile resourceprep = new XmppResource();

        private void TryOne(string input, string expected)
        {
            string output = resourceprep.Prepare(input);
            Assert.AreEqual(expected, output);
        }

        [Test] public void Test_Good()
        {
            TryOne("Test", "Test");
            TryOne("test", "test");
        }

        [Test]
        public void Test_Bad()
        {
            Assert.Throws<ProhibitedCharacterException>(() =>
            {
                TryOne("Test\x180E", null);
            });
        }
    }
}
#endif
