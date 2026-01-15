// Inject necessary modules for the Diagram component
//ej.diagrams.Diagram.Inject(
//    ej.diagrams.DataBinding,    // Enables data binding for the diagram
//    //ej.diagrams.HierarchicalTree // Enables hierarchical tree layout
//);




// Bind data to a DataManager and apply a query to fetch the data

var relationshipData = @Html.Raw(Json.Serialize(ViewBag.Nodes));

consol.log(relationshipData);
// Prepare the DataManager with the relationshipData
var dataManager = new ej.data.DataManager(relationshipData);

// Diagram setup
var diagram = new ej.diagrams.Diagram({
    width: '100%',                  // Make the diagram occupy full width
    height: '500px',                // Set the height of the diagram
    mode: 'SVG',                    // Use SVG rendering mode
    //snapSettings: { constraints: ej.diagrams.SnapConstraints.ShowLines }, // Disable snapping
    snapSettings: { constraints: ej.diagrams.SnapConstraints.None }, // Disable snapping
    dataSourceSettings: {
        id: 'ID',                 // Unique identifier for nodes
        parentId: 'ParentId',// Parent-child relationship based on reporting person
        dataManager: items,         // Data source is the DataManager
    },
    layout: {
        //type: 'ComplexHierarchicalTree',           // Layout type is Mind Map
        //type: 'RadialTree',           // Layout type is Mind Map
        //type: 'HierarchicalTree',           // Layout type is Mind Map
        //type: 'HierarchicalTree',           // Layout type is Mind Map
        //type: 'MindMap',           // Layout type is Mind Map
        type: 'MindMap',           // Layout type is Mind Map
        // margin: { left: 10, top: 10 }, // Add margins for layout
        horizontalSpacing: 30,        // Set horizontal spacing between nodes
        verticalSpacing: 30,          // Set vertical spacing between nodes
        orientation: 'TopToBottom',   // Orientation of the nodes is top to bottom
        getLayoutInfo: function (node, tree) {
            if (!tree.hasSubTree) {
                //tree.orientation = 'Vertical';  // Set vertical orientation if no sub-tree
                //tree.type = 'Alternate';        // Use alternate layout for leaves
            }
        },
    },
    getNodeDefaults: function (obj, diagram) {
        obj.height = 30;               // Default height of each node
        obj.width = 100;                // Default width of each node
        obj.shape = { type: 'Basic', shape: 'Rectangle' }; // Shape of the node is a rectangle
        obj.annotations = [
            {
                id: 'label1',               // Set ID for the annotation
                style: {
                    fontSize: 11,           // Font size of the label
                    bold: true,             // Make the font bold
                    fontFamily: 'Segoe UI', // Use Segoe UI font
                    color: 'white',         // Text color is white
                },
            },
        ];
        return obj;  // Return the customized node object
    },
    getConnectorDefaults: function (connector, diagram) {
        connector.targetDecorator.shape = 'Arrow'; // Use an arrow shape at the connector's target
        connector.type = 'Orthogonal';             // Use orthogonal connectors
        return connector;  // Return the customized connector object
    },
    setNodeTemplate: function (node) {
      
        let content = new ej.diagrams.StackPanel();
        content.id = node.id + '_outerstack';  // Assign a unique ID for the outer stack
        content.orientation = 'Horizontal';   // Arrange elements horizontally
        content.style.strokeColor = 'gray';   // Set border color to gray
        content.style.fill = node.data.fillColor; // Set background color based on role
        content.padding = { left: 10, right: 10, top: 10, bottom: 10 }; // Padding inside the stack
        content.cornerRadius = 20;


        // Create an inner content (e.g., image) element
        let innerContent = new ej.diagrams.ImageElement();
        innerContent.style.strokeColor = 'blue'; // Border color of the inner content
        innerContent.id = node.id + '_innerstack'; // Unique ID for inner content
        innerContent.source = node.data.Image;// Background color of the inner content
        innerContent.width = 50;                  // Set width of the inner content
        innerContent.height = 50;                 // Set height of the inner content
        innerContent.cornerRadius = 25;




        // Create a text element for the node's name
        let text = new ej.diagrams.TextElement();
        text.id = node.id + '_text';          // Unique ID for the text element
        text.content = node.data.AccountHolderName;        // Set text content as the node's Name
        text.margin = { left: 15, right: 5, top: 5, bottom: 5 }; // Set margins for the text
        text.style.color = 'black';           // Set text color to black

        content.children = [innerContent, text]; // Add the inner content and text to the stack panel
        return content;  // Return the custom stack panel as the node's template
    },
});

// Append the diagram to the HTML element with ID 'element'
diagram.appendTo('#element');

