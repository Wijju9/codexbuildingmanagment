import { AsyncPipe, NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { DashboardService } from '../../core/services/dashboard.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [NgFor, AsyncPipe],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
  readonly metrics$ = this.dashboardService.getMetrics();

  constructor(private readonly dashboardService: DashboardService) {}
}
