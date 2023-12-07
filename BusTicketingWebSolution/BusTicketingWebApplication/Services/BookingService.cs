using BusTicketingWebApplication.Exceptions;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using BusTicketingWebApplication.Models.DTOs;
using System.Linq;
using System.Net.Mail;
using System.Net;

namespace BusTicketingWebApplication.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IBusRepository _busRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookedSeatRepository _bookedSeatRepository;


        public BookingService(IBookingRepository bookingRepository, IBusRepository busRepository, IUserRepository userRepository, IBookedSeatRepository bookedSeatRepository)
        {
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            _busRepository = busRepository;
            _bookedSeatRepository = bookedSeatRepository;
        }
        public BookingDTO Add(BookingDTO bookingDTO)
        {
            var bus = _busRepository.GetById(bookingDTO.BusId);
            if (bookingDTO.SelectedSeats.Count <= 0 && bookingDTO.SelectedSeats.Count > 40) throw new InvalidNoOfTicketsEnteredException();
            if (bookingDTO.SelectedSeats.Count <= bus.AvailableSeats && bus.AvailableSeats > 0)
            {
                float Fare = 0;
                if (bus != null)
                {
                    Fare = bus.Cost;
                    bus.AvailableSeats -= bookingDTO.SelectedSeats.Count;
                    bus.BookedSeats += bookingDTO.SelectedSeats.Count;
                    _busRepository.Update(bus);
                    if (bookingDTO.SelectedSeats != null)
                    {
                        var bookedBusSeats = _bookedSeatRepository.GetById(bookingDTO.BusId);
                        if (bookedBusSeats == null)
                        {
                            BookedSeat bookedSeat = new BookedSeat();
                            bookedSeat.BusId = bus.Id;
                            bookedSeat.BookedSeats = bookingDTO.SelectedSeats;
                            _bookedSeatRepository.Add(bookedSeat);
                        }
                        else
                        {

                            //bookedBusSeats.BookedSeats  = new List<int>(bookedBusSeats.BookedSeats.Count +
                            //      bookingDTO.SelectedSeats.Count );

                            bookedBusSeats.BookedSeats.AddRange(bookingDTO.SelectedSeats);

                            // bookedBusSeats.BookedSeats= bookedBusSeats.BookedSeats.Concat(bookingDTO.SelectedSeats).ToList;

                            _bookedSeatRepository.Update(bookedBusSeats);
                        }
                    }
                }
                else
                {
                    throw new InvalidBusIdException();
                }
                Booking booking = new Booking
                {
                    UserName = bookingDTO.UserName,
                    BusId = bookingDTO.BusId,
                    Date = bookingDTO.Date,
                    Email=bookingDTO.Email,
                    SelectedSeats = bookingDTO.SelectedSeats,
                    TotalFare = bookingDTO.SelectedSeats.Count * Fare
                };
                var result = _bookingRepository.Add(booking);
                ScheduleAndSendEmail( result);
            }
            else
            {
                throw new NotEnoughBusSeatsAvailableException();
            }
            return bookingDTO;
        }
        public void ScheduleAndSendEmail( Booking booking)
        {
            // Calculate the delay until the target time
            //int delayMilliseconds = (int)(targetTime - DateTime.Now).TotalMilliseconds;

            //// Create a Timer with a callback function that sends the email
            //Timer timer = new Timer(state =>
            //{
                // Your email sending logic here
                string to = booking.Email;
                string subject = "Event Scheduled Email";
                string body = ($"Dear Sir/Madam \n !!! \nYour Bus Tickets are Booked!! \n Have a Safe and Happy Journey!!");

                SendNotificationEmail(to, subject, body);
            //}, null, delayMilliseconds, Timeout.Infinite);
        }
        public void SendNotificationEmail(string recipientEmail, string subject, string body)
        {
            try
            {
                string email = "nagavenkatasai7896@gmail.com";
                string password = "ufhcbpqnsnfzdqxr";

                // Create the email message
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(email);
                mail.To.Add(recipientEmail);
                mail.Subject = subject;
                mail.Body = body;

                // Set up SMTP client
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(email, password);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;

                // Send the email
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
        /// <summary>
        /// Share an event with specified email addresses
        /// </summary>
        /// <param name="eventId">The id of the event to be shared</param>
        /// <param name="recipientEmails">List of recipient emails</param>
        /// <returns>True if sharing is successful, false otherwise</returns>
        public bool ShareEvent(int bookingId, List<string> recipientEmails)
        {
            // Retrieve the event to be shared
            var bookingToShare = _bookingRepository.GetById(bookingId);
            if (bookingToShare != null)
            {
                // Customize the email subject and body for sharing
                string subject = "Shared Event: " + bookingToShare.Date;
                string body = $"Dear Recipient,\n\nYour tickets have been  scheduled for {bookingToShare.Date}. Don't miss it!";

                // Loop through recipient emails and send individual emails
                foreach (var recipientEmail in recipientEmails)
                {
                    SendNotificationEmail(recipientEmail, subject, body);
                }

                return true; // Sharing successful
            }
            return false; // Event not found
        }
        /// <summary>
        /// List of all created events
        /// </summary>
        /// <param name="userId">get the events list of specific user</param>
        /// <returns></returns>

        public List<Booking> GetBookings()
        {
            var bookings = _bookingRepository.GetAll();
            if (bookings != null)
            {
                return bookings.ToList();
            }
            throw new NoBookingsAvailableException();
        }



        public BookingDTO RemoveBooking(BookingDTO bookingDTO)
        {
            var BookingToBeRemoved = _bookingRepository.GetById(bookingDTO.Id);
            if (BookingToBeRemoved != null)
            {
                var result = _bookingRepository.Delete(bookingDTO.Id);
                if (result != null)
                {
                    return bookingDTO;
                }
            }
            return null;
        }
    }
}
