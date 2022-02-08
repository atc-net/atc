// ReSharper disable once CheckNamespace
namespace System.Data;

/// <summary>
/// Extensions for the <see cref="DataTable"/> class.
/// </summary>
public static class DataTableExtensions
{
    /// <summary>
    /// Sorts the table.
    /// </summary>
    /// <param name="dataTable">The data table.</param>
    /// <param name="sortOnColumn">The sort on column.</param>
    /// <param name="sortDirection">The sort direction.</param>
    public static DataTable SortTable(this DataTable dataTable, string sortOnColumn, SortDirectionType sortDirection)
    {
        if (dataTable is null)
        {
            throw new ArgumentNullException(nameof(dataTable));
        }

        if (string.IsNullOrEmpty(sortOnColumn))
        {
            throw new ArgumentNullOrDefaultException(nameof(sortOnColumn));
        }

        var sortExpression = sortDirection == SortDirectionType.Ascending
            ? sortOnColumn + " ASC"
            : sortOnColumn + " DESC";

        return FilterTable(dataTable, string.Empty, sortExpression);
    }

    /// <summary>
    /// Filters the table.
    /// </summary>
    /// <param name="dataTable">The data table.</param>
    /// <param name="filterExpression">The filter expression.</param>
    /// <param name="sortExpression">The sort expression.</param>
    public static DataTable FilterTable(this DataTable dataTable, string filterExpression, string sortExpression)
    {
        if (dataTable is null)
        {
            throw new ArgumentNullException(nameof(dataTable));
        }

        if (filterExpression is null)
        {
            throw new ArgumentNullException(nameof(filterExpression));
        }

        if (sortExpression is null)
        {
            throw new ArgumentNullException(nameof(sortExpression));
        }

        var draFiltered = dataTable.Select(filterExpression, sortExpression);
        var dtFiltered = dataTable.Clone();
        foreach (var drOld in draFiltered)
        {
            var dr = dtFiltered.NewRow();
            for (var i = 0; i < dataTable.Columns.Count; i++)
            {
                dr[dataTable.Columns[i].ColumnName] = drOld[dataTable.Columns[i].ColumnName];
            }

            dtFiltered.Rows.Add(dr);
        }

        return dtFiltered;
    }

    /// <summary>
    /// Gets the group count.
    /// </summary>
    /// <param name="dataTable">The data table.</param>
    /// <param name="countOnColumn">The count on column.</param>
    public static Dictionary<string, int> GetGroupCount(this DataTable dataTable, string countOnColumn)
    {
        if (dataTable is null)
        {
            throw new ArgumentNullException(nameof(dataTable));
        }

        if (string.IsNullOrEmpty(countOnColumn))
        {
            throw new ArgumentNullOrDefaultException(nameof(countOnColumn));
        }

        var list = new Dictionary<string, int>(StringComparer.Ordinal);
        foreach (var key in
                 from DataRow dr
                     in dataTable.Rows
                 select dr[countOnColumn].ToString())
        {
            if (list.ContainsKey(key))
            {
                list[key] = list[key] + 1;
            }
            else
            {
                list.Add(key, 1);
            }
        }

        return list;
    }

    /// <summary>
    /// Toes the collection.
    /// </summary>
    /// <typeparam name="T">
    /// The object template.
    /// </typeparam>
    /// <param name="dataTable">The data table.</param>
    /// <returns>The list of T.</returns>
    public static List<T> ToCollection<T>(this DataTable dataTable)
    {
        if (dataTable is null)
        {
            throw new ArgumentNullException(nameof(dataTable));
        }

        var list = new List<T>();
        var typeClass = typeof(T);
        var propertyInfos = typeClass.GetProperties();
        var dataColumns = dataTable.Columns.Cast<DataColumn>().ToList();
        foreach (DataRow item in dataTable.Rows)
        {
            var cn = (T)Activator.CreateInstance(typeClass);
            foreach (var propertyInfo in
                     from pc in propertyInfos
                     let d = dataColumns.Find(c => string.Equals(c.ColumnName, pc.Name, StringComparison.Ordinal))
                     where d is not null
                     select pc)
            {
                propertyInfo.SetValue(cn, item[propertyInfo.Name], null);
            }

            list.Add(cn);
        }

        return list;
    }

    /// <summary>
    /// Convert to XPathNodeIterator from a DataTable.
    /// </summary>
    /// <param name="dataTable">The data table.</param>
    public static XPathNodeIterator? ToXPathNodeIterator(this DataTable dataTable)
    {
        if (dataTable is null)
        {
            throw new ArgumentNullException(nameof(dataTable));
        }

        var xmlDocument = new XmlDocument();
        using (var ds = new DataSet("DataSet"))
        {
            ds.Locale = GlobalizationConstants.EnglishCultureInfo;
            ds.Tables.Add(dataTable);
            xmlDocument.LoadXml(ds.GetXml());
        }

        var xPathNavigator = xmlDocument.CreateNavigator();
        return xPathNavigator.Select(".");
    }
}