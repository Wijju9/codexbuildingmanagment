package com.example.pgmanager.ui

import android.os.Bundle
import android.widget.TextView
import androidx.activity.ComponentActivity
import androidx.activity.viewModels
import com.example.pgmanager.R

class MainActivity : ComponentActivity() {

    private val viewModel: MainViewModel by viewModels()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val summaryText = findViewById<TextView>(R.id.dashboardSummary)
        viewModel.summary.observe(this) { value ->
            summaryText.text = value
        }
    }
}
