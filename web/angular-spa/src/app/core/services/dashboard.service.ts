import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { DashboardMetric } from '../models/dashboard.model';

@Injectable({ providedIn: 'root' })
export class DashboardService {
  getMetrics(): Observable<DashboardMetric[]> {
    return of([
      { label: 'Properties', value: '6' },
      { label: 'Active Guests', value: '214' },
      { label: 'Occupancy', value: '88%' },
      { label: 'Pending Invoices', value: '$12,460' }
    ]);
  }
}
