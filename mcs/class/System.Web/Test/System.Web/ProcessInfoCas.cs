//
// ProcessInfoCas.cs - CAS unit tests for System.Web.ProcessInfo
//
// Author:
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// Copyright (C) 2005 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using NUnit.Framework;

using System;
using System.Security;
using System.Security.Permissions;
using System.Web;

namespace MonoCasTests.System.Web {

	[TestFixture]
	[Category ("CAS")]
	public class ProcessInfoCas : AspNetHostingMinimal {

		private void CheckProperties (ProcessInfo pi)
		{
			Assert.AreEqual (TimeSpan.Zero, pi.Age, "Age");
			Assert.AreEqual (0, pi.PeakMemoryUsed, "PeakMemoryUsed");
			Assert.AreEqual (0, pi.ProcessID, "ProcessID");
			Assert.AreEqual (0, pi.RequestCount, "RequestCount");
			Assert.AreEqual (ProcessShutdownReason.None, pi.ShutdownReason, "ShutdownReason");
			Assert.AreEqual (DateTime.MinValue, pi.StartTime, "StartTime");
			Assert.AreEqual (0, (int)pi.Status, "Status");
		}

		[Test]
		[PermissionSet (SecurityAction.Deny, Unrestricted = true)]
		public void Constructor0 ()
		{
			ProcessInfo pi = new ProcessInfo ();
			CheckProperties (pi);
			pi.SetAll (DateTime.MinValue, TimeSpan.Zero, 0, 0, 0, ProcessShutdownReason.None, 0);
			CheckProperties (pi);
		}

		[Test]
		[PermissionSet (SecurityAction.Deny, Unrestricted = true)]
		public void Constructor7 ()
		{
			ProcessInfo pi = new ProcessInfo (DateTime.MinValue, TimeSpan.Zero, 0, 0, 0, ProcessShutdownReason.None, 0);
			CheckProperties (pi);
		}

		// LinkDemand

		public override Type Type {
			get { return typeof (ProcessInfo); }
		}
	}
}
