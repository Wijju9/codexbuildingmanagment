package com.example.pgmanager.ui

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.example.pgmanager.data.DashboardRepository

class MainViewModel(
    private val dashboardRepository: DashboardRepository = DashboardRepository()
) : ViewModel() {

    private val _summary = MutableLiveData(
        dashboardRepository.getMetrics().joinToString(separator = "\n") { "${it.label}: ${it.value}" }
    )

    val summary: LiveData<String> = _summary
}
