import { Component } from '@angular/core';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent {
  events = [
    {
      name: 'Tech Innovators Conference',
      date: '2025-09-12',
      price: 3500,
      category: 'Conference'
    },
    {
      name: 'Creative Writing Workshop',
      date: '2025-10-05',
      price: 800,
      category: 'Workshop'
    },
    {
      name: 'Rock Music Concert',
      date: '2025-11-20',
      price: 2500,
      category: 'Concert'
    },
    {
      name: 'AI & Machine Learning Summit',
      date: '2025-12-02',
      price: 5000,
      category: 'Conference'
    }
  ];
}
