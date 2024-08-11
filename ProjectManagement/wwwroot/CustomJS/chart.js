function createDonutChart(data) {
    var chartData = JSON.parse(data);

    am5.ready(function () {
        var root = am5.Root.new("chartdiv");

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

        // Add tooltips
        series.slices.template.set("tooltipText", "{category}: {value}%");

        // Create a container for the legend
        var legendContainer = container.children.push(am5.Container.new(root, {
            layout: root.verticalLayout,
            width: am5.percent(20), // Space allocated for the legend
            height: am5.percent(100),
            marginLeft: 20 // Space between chart and legend
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