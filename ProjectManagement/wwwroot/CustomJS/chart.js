let root; // Declare a global variable to store the root instance

function createDonutChart(data) {
    var chartData = JSON.parse(data);
    // Check if there's an existing root and dispose of it
    if (root) {
        root.dispose();
    }

    // Initialize the chart only once am5 is ready
    am5.ready(function () {
        // Create a new root instance and store it in the global variable
        root = am5.Root.new("chartdiv");

        root.setThemes([
            am5themes_Animated.new(root)
        ]);

        // Create a container with horizontal layout
        var container = root.container.children.push(am5.Container.new(root, {
            layout: root.horizontalLayout,
            width: am5.percent(100),
            height: am5.percent(100)
        }));

        // Create the chart
        var chart = container.children.push(am5percent.PieChart.new(root, {
            innerRadius: am5.percent(40), // Creates the donut effect
            width: am5.percent(80) // Adjust width as needed
        }));

        var series = chart.series.push(am5percent.PieSeries.new(root, {
            name: "Series",
            valueField: "WorkPercent",
            categoryField: "strTaskName"
        }));

        series.data.setAll(chartData);

        // Format tooltip to show tmWorking
        series.slices.template.set("tooltipText", "{category}: {tmWorking}");

        // Create a container for the legend
        var legendContainer = container.children.push(am5.Container.new(root, {
            layout: root.verticalLayout,
            width: am5.percent(20), // Space allocated for the legend
            height: am5.percent(100),
            marginTop: 20, // Adjusted top margin to move the legend slightly down
            marginLeft: 0 // Space between chart and legend
        }));

        // Add the legend
        var legend = legendContainer.children.push(am5.Legend.new(root, {
            layout: root.verticalLayout,
            width: am5.percent(100),
            height: am5.percent(100)
        }));

        legend.data.setAll(series.dataItems);

        // Ensure the series appears
        series.appear(1000, 100);
    });
}
