using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Tests
{
    [TestFixture]
    public class UpdateableSpintTests
    {
        [Test]
        public void Wait_NoPulse_ReturnFalse()
        {
            UpdateableSpint spin = new UpdateableSpint();
            bool wasPulsed = spin.Wait(TimeSpan.FromMilliseconds(10));
            Assert.IsFalse(wasPulsed);
        }

        [Test]
        public void Wait_Pulse_ReturnTrue()
        {
            UpdateableSpint spin = new UpdateableSpint();

            Task.Factory.StartNew(() => {
                Thread.Sleep(100);
                spin.Set();

            });

            bool wasPulsed = spin.Wait(TimeSpan.FromSeconds(10));
            Assert.IsTrue(wasPulsed);
        }

        [Test]
        public void Wait50MiliSec_CallIsActuallyWaitingFor50Milisec()
        {
            UpdateableSpint spin = new UpdateableSpint();
            Stopwatch watch = new Stopwatch();

            watch.Start();

            spin.Wait(TimeSpan.FromMilliseconds(50));

            watch.Stop();

            TimeSpan actual = TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds);
            TimeSpan left = TimeSpan.FromMilliseconds(50 - (50 *0.1));
            TimeSpan right = TimeSpan.FromMilliseconds(50 + (50 * 0.1));

            Assert.IsTrue(actual > left && actual < right);
        }

        [Test]
        public void Wait50MiliSec_UpdateAfer300_TotalWaitingAprox800()
        {
            UpdateableSpint spin = new UpdateableSpint();
            Stopwatch watch = new Stopwatch();

            watch.Start();

            const int timeout = 500;
            const int spanBeforeUpdate = 300;

            Task.Factory.StartNew(() => {
                Thread.Sleep(spanBeforeUpdate);
                spin.UpdateTimeOut();

            });

            spin.Wait(TimeSpan.FromMilliseconds(timeout));

            watch.Stop();

            TimeSpan actual = TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds);

            const int expected = timeout + spanBeforeUpdate;

            TimeSpan left = TimeSpan.FromMilliseconds(expected - (expected * 0.1));
            TimeSpan right = TimeSpan.FromMilliseconds(expected + (expected * 0.1));

            Assert.IsTrue(actual > left && actual < right);
        }
    }
}
