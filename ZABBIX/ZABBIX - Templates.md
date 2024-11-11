
# Zabbix Templates Documentation

## Overview
Zabbix templates are designed to standardize and simplify the monitoring of multiple hosts by applying predefined configurations. Templates consist of several components:

- **Items**: Predefined metrics that collect data, such as CPU load or disk space.
- **Triggers**: Conditions that determine when an alert should be triggered.
- **Graphs**: Visualization tools for displaying collected data.
- **Applications**: Logical grouping of items for easier management.
- **Screens**: Dashboards with various visual elements.

## Creating and Managing Templates

In order to create a template for different hosts: 
1. Go to the `Configuration` tab and select `Templates`.
2. Click on `Create template`.
3. Define the template properties:
   - **Template name**: The unique identifier for the template.
   - **Groups**: Specify a group to assign the template.
   - **Macros**: User-defined variables for template customization.
4. Add items, triggers, graphs, and more to the template.

Once you have create a template you will be able to use it when you create a new host to create its dashboards, metrics and alerts. 

Also you can still using all the built-in templates that Zabbix offers by default or even customize it. 

In order to trigger alarms we can define triggers that will execute an action: 

Triggers define conditions for raising alarms. They include:
- **Expression**: The condition that must be met (example: CPU load > 80%).
- **Severity**: The level of importance of the trigger (example: critical, warning).
- **Dependencies**: Links between triggers to prevent duplicate alerts.

### Graphs
Graphs provide a visual representation of collected data for easier analysis. You can add multiple items to a single graph for comparison.

For more detailed instructions, visit the [Zabbix Template Documentation](https://www.zabbix.com/documentation/current/en/manual/config/templates/template).
