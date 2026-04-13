package com.example.pgmanager.data

import com.example.pgmanager.domain.DashboardMetric

class DashboardRepository {
    fun getMetrics(): List<DashboardMetric> = listOf(
        DashboardMetric("Properties", "6"),
        DashboardMetric("Active Guests", "214"),
        DashboardMetric("Occupancy", "88%")
    )
}
