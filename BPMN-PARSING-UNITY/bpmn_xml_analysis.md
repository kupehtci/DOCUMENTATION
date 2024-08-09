# BPMN XML DECONSTRUCTION


## TASK

```XML
<bpmn:task id="Activity_1gzu948" name="FOLLOW PLAYER">
	<bpmn:incoming>Flow_01phsdv</bpmn:incoming>
	<bpmn:outgoing>Flow_1ed3zvm</bpmn:outgoing>
</bpmn:task>
```

## SEQUENCE FLOW

A sequence flow line if has an conditional expression, inside XML ```<bpmn:sequenceFlow> </bpmn:sequenceFlow>``` needs to have an expression: 

	```<bpmn:conditionExpression xsi:type="bpmn:tFormalExpression">=player-near = true</bpmn:conditionExpression>```
In the form of: 

	```<bpmn:conditionExpression xsi:type="bpmn:tFormalExpression">=player-near = true</bpmn:conditionExpression>```
```XML
<bpmn:sequenceFlow id="Flow_01phsdv" sourceRef="player-near-gateway" targetRef="Activity_1gzu948">
      <bpmn:conditionExpression xsi:type="bpmn:tFormalExpression">=player-near = true</bpmn:conditionExpression>
</bpmn:sequenceFlow>
```

## START EVENT AND END EVENT


```XML

<bpmn:startEvent id="StartEvent_1" name="Start">
      <bpmn:outgoing>Flow_11y9y90</bpmn:outgoing>
</bpmn:startEvent>

```


## GATEWAY 

A exclusive gateway looks like this: 

```XML

<bpmn:exclusiveGateway id="Gateway_0ac59ld" name="PLAYER CLOSE? ">
      <bpmn:extensionElements />
      <bpmn:incoming>Flow_1ed3zvm</bpmn:incoming>
      <bpmn:incoming>Flow_1yt890r</bpmn:incoming>
      <bpmn:outgoing>Flow_1bgxgo3</bpmn:outgoing>
</bpmn:exclusiveGateway>

```

having a reference of the id of the incoming sequence flow and the outgoing


## BASIC TASK

```XML

<bpmn:task id="Activity_00twabi" name="IDLE">
      <bpmn:incoming>Flow_11y9y90</bpmn:incoming>
      <bpmn:outgoing>Flow_0b7qw0f</bpmn:outgoing>
</bpmn:task>

```

Having outcoming and incoming tags that has the id of the sequence flow of input and output


## SCRIPT TASK

Example of a script tasks using javascript via **CDATA**
```XML
<scriptTask id="task" name="Script Task" scriptFormat="javascript">
  <script>
    <![CDATA[
	    var address = S(customer).element("address");
	    var city = XML("<city>New York</city>");
	    address.append(city);
	    execution.setVariable("address", address.toString());
    ]]>
  </script>
</scriptTask>
```



```XML

<bpmn:scriptTask id="Activity_00e25zp">
      <bpmn:extensionElements>
        <zeebe:ioMapping>
          <zeebe:input target="player_position" />
          <zeebe:input target="enemy_position" />
          <zeebe:output target="player-near" />
        </zeebe:ioMapping>
        <zeebe:properties>
          <zeebe:property />
        </zeebe:properties>
        <zeebe:script expression="=  &#10;if((enemy_position - player_position).magnitude &#60; 1.0f)&#10;  {&#10;    player-near = true; &#10;  }" resultVariable="player-near" />
      </bpmn:extensionElements>
    </bpmn:scriptTask>

```

## PARTICIPANTS



```XML
<bpmn:collaboration id="Collaboration_0esr49h">
    <bpmn:participant id="Participant_1rtllqr" name = "ENEMY" processRef="human-participant-id" />
</bpmn:collaboration>
 ```
Each participant has a "processRef="..."" that indicated the process ID. 
All elements that belongs to that participant needs to be inside a: 

```XML
	<bpmn:process id="human-participant-id" isExecutable="true">
		<!--All elements belonging to human-participant-id that are inside its pool-->
	</bpmn:process>
```

"isExecutable" defines that is defined as 

IDEAS

*    Have a Camunda connector in their marketplace that gestiones
*    C# code transformation using XML from the modeler