import React, { useEffect, useState } from 'react';
import './BusTicket.css';
import { useLocation } from 'react-router-dom';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';

const BusTicket = () => {
  const location = useLocation();
  const [ticketDetails, setTicketDetails] = useState({
    thisBus: localStorage.getItem('thisBus') || '',
    thisDate: localStorage.getItem('thisDate') || '',
    type: 'Standard',
    selectedSeats: JSON.parse(localStorage.getItem('selectedSeats') || '[]'),
    toLocation: localStorage.getItem('toLocation') || '',
    fromLocation: localStorage.getItem('fromLocation') || '',
    startTime: '12:00 PM',
    cost: localStorage.getItem('cost') || '',
  });

  useEffect(() => {
    // Fetch additional details from the server if needed
  }, []);

  const downloadTicket = () => {
    const element = document.getElementById('ticket-container');

    if (element) {
      html2canvas(element).then((canvas) => {
        const imgData = canvas.toDataURL('image/png');
        const pdf = new jsPDF();
        const pdfWidth = pdf.internal.pageSize.getWidth();
        const pdfHeight = pdf.internal.pageSize.getHeight();
        pdf.addImage(imgData, 'JPEG', 0, 0, pdfWidth, pdfHeight);
        pdf.save(`BusTicket_${ticketDetails.thisBus}_${ticketDetails.thisDate}.pdf`);
      });
    }
  };

  return (
    <div id="ticket-container" className="ticket-container">
      <div className="ticket-header">
        <h1>Bus Ticket</h1>
      </div>
      <div className="ticket-details">
        <div className="detail-row">
          <span>Bus ID:</span>
          <span>{ticketDetails.thisBus}</span>
        </div>
        <div className="detail-row">
          <span>Date:</span>
          <span>{ticketDetails.thisDate}</span>
        </div>
        <div className="detail-row">
          <span>Type:</span>
          <span>{ticketDetails.type}</span>
        </div>
        <div className="detail-row">
          <span>Selected Seats:</span>
          <span>{ticketDetails.selectedSeats.join(', ')}</span>
        </div>
        <div className="detail-row">
          <span>From:</span>
          <span>{ticketDetails.fromLocation}</span>
        </div>
        <div className="detail-row">
          <span>To:</span>
          <span>{ticketDetails.toLocation}</span>
        </div>
        <div className="detail-row">
          <span>Start Time:</span>
          <span>{ticketDetails.startTime}</span>
        </div>
        <div className="detail-row">
          <span>Cost:</span>
          <span>₹{ticketDetails.cost}</span>
        </div>
      </div>
      <div className="ticket-download">
        <button onClick={downloadTicket}>Download Ticket</button>
      </div>
    </div>
  );
};

export default BusTicket;
