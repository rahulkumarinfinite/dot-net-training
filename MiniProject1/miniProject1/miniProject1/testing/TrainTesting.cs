using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using miniProject1.REpo; // Adjust if your namespace is different



    namespace miniProject1.Tests
    {
    
        [TestFixture]
        public class TrainRepo_Testing
        {
            TrainRepo repo;

            [SetUp]
            public void ArrangeObjects()
            {
                repo = new TrainRepo();
            }

            [Test]
            public void AddTrain_()
            {
                // Act & Assert
                ClassicAssert.DoesNotThrow(() =>
                {
                    repo.AddTrain("Test Express", "CityX", "CityY", 20, 30, 10, 400.0f);
                });
            }

            [Test]
            public void DeleteTrain_()
            {
                ClassicAssert.DoesNotThrow(() =>
                {
                    repo.DeleteTrain(-999); 
                });
            }

            [Test]
            public void BookTicket_()
            {
                ClassicAssert.DoesNotThrow(() =>
                {
                    repo.BookTicket("John Doe", "1234567890", "john@mail.com", 1, DateTime.Today.AddDays(1), "Sleeper");
                });
            }

            [Test]
            public void CancelTicket_()
            {
                ClassicAssert.DoesNotThrow(() =>
                {
                    repo.CancelTicket(-1, DateTime.Today.AddDays(1));
                });
            }

            [Test]
            public void ReservationReport_()
            {
                DateTime start = DateTime.Today.AddDays(-30);
                DateTime end = DateTime.Today;

                ClassicAssert.DoesNotThrow(() =>
                {
                    repo.ReservationReport(start, end);
                });
            }

            [Test]
            public void CancelReport_()
            {
                DateTime start = DateTime.Today.AddDays(-30);
                DateTime end = DateTime.Today;

                ClassicAssert.DoesNotThrow(() =>
                {
                    repo.CancelReport(start, end);
                });
            }

            [Test]
            public void UpdateTrain_()
            {
                ClassicAssert.DoesNotThrow(() =>
                {
                    repo.UpdateTrain(1, "Updated Express", "NewSource", "NewDest", 40, 40, 20, 600.0f);
                });
            }

            [Test]
            public void ViewTrains_()
            {
                ClassicAssert.DoesNotThrow(() =>
                {
                    repo.ViewTrains();
                });
            }
        }
    }

