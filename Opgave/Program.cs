using ClassLibrary.Application;
using ClassLibrary.DataAccess;
using ClassLibrary.Presentation;

var controller = new BookingController(
    new MemberRepository(),
    new FitnessClassRepository(),
    new BookingRepository());

var ui = new BookingUI(controller);
ui.BookClass();