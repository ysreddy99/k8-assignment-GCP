$(document).ready(function() {
    // Fetch data from API
    var apiUrl = window.API_URL;
    $.getJSON(apiUrl || 'http://34.31.121.179/cities', function(data) {
      // Create table headers
      var tableHeaders = '<tr><th>Name</th><th>Country</th><th>Population</th><th>Latitude</th><th>Longitude</th></tr>';
  
      // Iterate over each city and create table rows
      var tableRows = '';
      $.each(data, function(index, city) {
        tableRows += '<tr>';
        tableRows += '<td>' + city.name + '</td>';
        tableRows += '<td>' + city.country + '</td>';
        tableRows += '<td>' + city.population + '</td>';
        tableRows += '<td>' + city.latitude + '</td>';
        tableRows += '<td>' + city.longitude + '</td>';
        tableRows += '</tr>';
      });
  
      // Append table headers and rows to the table body
      $('#cityTable').html(tableHeaders + tableRows);
    });
  });
  