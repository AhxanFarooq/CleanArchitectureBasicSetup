interface TableColumn {
    key: string;            // Key of the data object
    title: string;          // Display title for the column
    isActionColumn?: boolean; // Determine if this is an action column
    buttons:string[];
    width:string;
  }
  