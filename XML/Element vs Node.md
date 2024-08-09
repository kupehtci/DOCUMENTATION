#XML 

The Node object is the primary data type for the entire DOM.

A node can be an element node, an attribute node, a text node, or any other of the node types explained in the "Node types" chapter.

An XML element is everything from (including) the element's start tag to (including) the element's end tag.


#### <span style="color:#64eda8"> DOM SPECIFICATION </span>

Different W3C specifications define different sets of "Node" types.

Thus, the [**DOM spec**](http://www.w3.org/TR/1998/REC-DOM-Level-1-19981001/level-one-core.html#ID-1590626202) defines the following types of nodes:

- `Document` -- `Element` (maximum of one), `ProcessingInstruction`, `Comment`, `DocumentType`
- `DocumentFragment` -- `Element`, `ProcessingInstruction`, `Comment`, `Text`, `CDATASection`, `EntityReference`
- `DocumentType` -- no children 
- `EntityReference` -- `Element`, `ProcessingInstruction`, `Comment`, `Text`, `CDATASection`, `EntityReference`
- `Element` -- `Element`, `Text`, `Comment`, `ProcessingInstruction`, `CDATASection`, `EntityReference`
- `Attr` -- `Text`, `EntityReference`
- `ProcessingInstruction` -- no children 
- `Comment` -- no children 
- `Text` -- no children 
- `CDATASection` -- no children 
- `Entity` -- `Element`, `ProcessingInstruction`, `Comment`, `Text`, `CDATASection`, `EntityReference`
- `Notation` -- no children