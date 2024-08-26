function createLineChart(jsonData) {
    if (root) {
        root.dispose();
    }

    // Parse the JSON data
    var teamData = JSON.parse(jsonData);

    // Group data by strUserName
    var groupedData = {};
    teamData.forEach(item => {
        if (!groupedData[item.strUserName]) {
            groupedData[item.strUserName] = [];
        }
        var timeParts = item.tmWorking.split(':');
        var totalMinutes = parseInt(timeParts[0]) * 60 + parseInt(timeParts[1]) + parseInt(timeParts[2]) / 60;
        groupedData[item.strUserName].push({
            dteInsertDate: new Date(item.dteInsertDate).getTime(),
            tmWorking: totalMinutes
        });
    });

    am5.ready(function () {
        root = am5.Root.new("chartdiv");

        root.setThemes([
            am5themes_Animated.new(root)
        ]);

        var chart = root.container.children.push(am5xy.XYChart.new(root, {
            panX: true,
            panY: true,
            wheelX: "panX",
            wheelY: "zoomX",
            pinchZoomX: true
        }));

        // Create X-axis (Date)
        var xAxis = chart.xAxes.push(am5xy.DateAxis.new(root, {
            maxDeviation: 0.2,
            baseInterval: {
                timeUnit: "day",
                count: 1
            },
            renderer: am5xy.AxisRendererX.new(root, {
                minorGridEnabled: true
            }),
            tooltip: am5.Tooltip.new(root, {})
        }));

        // Create Y-axis (TimeSpan in minutes)
        var yAxis = chart.yAxes.push(am5xy.ValueAxis.new(root, {
            renderer: am5xy.AxisRendererY.new(root, {})
        }));

        // Create a series for each user
        for (var userName in groupedData) {
            if (groupedData.hasOwnProperty(userName)) {
                var series = chart.series.push(am5xy.LineSeries.new(root, {
                    name: userName,
                    xAxis: xAxis,
                    yAxis: yAxis,
                    valueYField: "tmWorking",
                    valueXField: "dteInsertDate",
                    tooltip: am5.Tooltip.new(root, {
                        pointerOrientation: "horizontal",
                        labelText: "{valueY} minutes"
                    })
                }));

                series.data.setAll(groupedData[userName]);
                series.appear();
            }
        }

        // Add cursor
        var cursor = chart.set("cursor", am5xy.XYCursor.new(root, {
            behavior: "none"
        }));
        cursor.lineY.set("visible", false);

        // Add scrollbar
        chart.set("scrollbarX", am5.Scrollbar.new(root, {
            orientation: "horizontal"
        }));

        chart.set("scrollbarY", am5.Scrollbar.new(root, {
            orientation: "vertical"
        }));

        // Add legend
        var legend = chart.rightAxesContainer.children.push(am5.Legend.new(root, {
            width: 200,
            paddingLeft: 15,
            height: am5.percent(100)
        }));

        legend.data.setAll(chart.series.values);

        chart.appear(1000, 100);
    });
}
