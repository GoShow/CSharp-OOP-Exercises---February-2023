using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests;

public class HotelTests
{
    private Hotel hotel;

    [SetUp]
    public void Setup()
    {
        hotel = new("Radison", 5);
    }

    [Test]
    public void ConstructorSetsFullNameAndCategoryCorrectly()
    {
        string expectedFullName = "Radison";
        int expectedCategory = 3;

        Hotel hotel = new(expectedFullName, expectedCategory);

        Assert.That(hotel.FullName, Is.EqualTo(expectedFullName));
        Assert.That(hotel.Category, Is.EqualTo(expectedCategory));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("     ")]
    public void FullNameSetterThrowsExceptionWhenValueIsNullOrWhiteSpace(string fullName)
    {
        Assert.Throws<ArgumentNullException>(() => new Hotel(fullName, 5));
    }

    [TestCase(-10)]
    [TestCase(0)]
    [TestCase(6)]
    [TestCase(10)]
    public void CategorySetterThrowsExceptionWhenValueOutOfRange(int category)
    {
        Assert.Throws<ArgumentException>(() => new Hotel("Radison", category));
    }

    [Test]
    public void AddRoomAddsRoomCorrectly()
    {
        Room room = new(3, 100);

        hotel.AddRoom(room);

        Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
    }

    [TestCase(0)]
    [TestCase(-10)]
    public void BookRoomThrowsExceptionWhenThereAreNoAdults(int adults)
    {
        Room room = new(3, 100);

        hotel.AddRoom(room);

        Assert.Throws<ArgumentException>(() => hotel.BookRoom(adults, 2, 3, 200));
    }

    [TestCase(-1)]
    [TestCase(-10)]
    public void BookRoomThrowsExceptionWhenChildrenAreLessThanZero(int children)
    {
        Room room = new(3, 100);

        hotel.AddRoom(room);

        Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, children, 3, 200));
    }

    [TestCase(0)]
    [TestCase(-10)]
    public void BookRoomThrowsExceptionWhenThereIsNoResidenceDuration(
        int residenceDuration)
    {
        Room room = new(3, 53);

        hotel.AddRoom(room);

        Assert.Throws<ArgumentException>(()
            => hotel.BookRoom(2, 1, residenceDuration, 200));
    }

    [Test]
    public void BookRoomNoTurnoverWhenNotEnoughBeds()
    {
        Room room = new(3, 100);

        hotel.AddRoom(room);
        hotel.BookRoom(4, 1, 2, 200);

        Assert.That(hotel.Turnover.Equals(0));
    }

    [Test]
    public void BookRoomNoBookingWhenBudgetTooLow()
    {
        Room room = new(5, 70);
        hotel.AddRoom(room);

        hotel.BookRoom(4, 1, 2, 100);

        double expectedTurnover = 0;

        Assert.That(expectedTurnover, Is.EqualTo(hotel.Turnover));
        Assert.That(hotel.Bookings.Count, Is.EqualTo(0));
        Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
    }

    [Test]
    public void BookRoomBooksRoomProperly()
    {
        Room room = new(5, 70);

        hotel.AddRoom(room);
        hotel.BookRoom(4, 1, 2, 150);

        double expectedTurnover = 140;

        Assert.That(expectedTurnover, Is.EqualTo(hotel.Turnover));
        Assert.That(hotel.Bookings.Count, Is.EqualTo(1));
        Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
    }
}