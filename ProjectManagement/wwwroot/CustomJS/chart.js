﻿function createDonutChart(data) {
    var chartData = JSON.parse(data);

    am5.ready(function () {
        var root = am5.Root.new("chartdiv");

        root.setThemes([
            am5themes_Animated.new(root)
        ]);

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

        // Add event handler for slice clicks
        series.slices.template.events.on("hit", function (ev) {
            var slice = ev.target;
            var dataItem = slice.dataItem;
            var title = dataItem.category;
            var value = dataItem.value;

            // Display custom information when a slice is clicked
            console.log("Task:", title, "Percent:", value, "Work Time:", value);
        });

        series.appear(1000, 100);
    });
}
