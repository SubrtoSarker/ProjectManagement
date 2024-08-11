function createDonutChart(data) {
    var chartData = JSON.parse(data);

    am5.ready(function () {
        var root = am5.Root.new("chartdiv");

        root.setThemes([
            am5themes_Animated.new(root)
        ]);

        // Create the chart
        var chart = root.container.children.push(am5percent.PieChart.new(root, {
            layout: root.verticalLayout
        }));

        var series = chart.series.push(am5percent.PieSeries.new(root, {
            name: "Series",
            valueField: "WorkPercent",
            categoryField: "strTaskName"
        }));

        series.data.setAll(chartData);

        // Add tooltips
        series.slices.template.set("tooltipText", "{category}: {value}%");
        series.slices.template.set("tooltipY", 0);
        series.slices.template.set("tooltipX", 0);

        // Add legend to the same container
        var legend = root.container.children.push(am5.Legend.new(root, {
            position: "bottom",
            layout: root.horizontalLayout,
            marginTop: 20, // Space between chart and legend
            marginBottom: 10 // Additional bottom margin to avoid overlap
        }));

        legend.data.setAll(series.dataItems);

        // Ensure the series appears
        series.appear(1000, 100);
    });
}
