let tempArray = [];
let temp = [];
let numActivities = 0;

function showNewActForm() {
    document.getElementById('newActivityForm').style.display = 'block';
    document.getElementById('newActivityBtn').style.display = 'none';
}

function hideNewActForm() {
    document.getElementById('newActivityForm').style.display = 'none';
    document.getElementById('newActivityBtn').style.display = 'block';
}

function showNewRoutineForm() {
    document.getElementById('newRoutineForm').style.display = 'block';
    document.getElementById('newRoutineBtn').style.display = 'none';
}

function hideNewRoutineForm() {
    document.getElementById('newRoutineForm').style.display = 'none';
    document.getElementById('newRoutineBtn').style.display = 'block';
}

function updateSelectedRoutine(num) {
    document.getElementById('selectedRoutine').value = num;
}

function editAct(index) {
    document.getElementById('activityName-' + index).style.display = 'none';
    document.getElementById('activityField-' + index).style.display = 'inline';
    document.getElementById('deleteBtn-' + index).style.display = 'none';
    document.getElementById('saveBtn-' + index).style.display = 'inline';

    document.getElementById('activityField-' + index).focus();
}

function updateTempArray() {
    tempArray = JSON.parse(document.getElementById('activitiesString').value);
}

function updateActivityArray() {
    document.getElementById('activitiesString').value = JSON.stringify(tempArray);
}

function addActivity(num) {
    tempArray.push(num);
    updateActivityArray();
    renderRoutineActivities();
}

function subtractActivity(index) {
    tempArray.splice(index, 1);
    updateActivityArray();
    renderRoutineActivities();
}

function showOptions(index) {
    document.getElementById('activityName-' + index).style.display = 'none';
    document.getElementById('options-' + index).style.display = 'inline';
}

function hideOptions(index) {
    document.getElementById('activityName-' + index).style.display = 'inline';
    document.getElementById('options-' + index).style.display = 'none';
}

function getActivityName(id) {
    for (let i = 0; i < numActivities; i++) {
        const target = document.getElementById('idRef-' + i).value.split('^')[0];
        if (id == target)
            return document.getElementById('idRef-' + i).value.split('^')[1];
    }
    return "";
}

function getActivityNames(routineLength) {
    updateTempArray();
    for (let i = 0; i < routineLength; i++) {
        document.getElementById('routineActName-' + i).innerHTML =
            getActivityName(document.getElementById('routineActID-' + i).value, numActivities)
    }
}

function renderRoutineActivities() {
    const actTable = document.getElementById('routineActivities');

    while (actTable.firstChild) {
        actTable.removeChild(actTable.firstChild);
    }

    for (let i = 0; i < tempArray.length; i++) {

        const removeBtn = document.createElement('BUTTON');
        removeBtn.setAttribute('onclick', 'subtractActivity(' + i + ')');
        removeBtn.setAttribute('id', 'subtractActivity-' + i);
        removeBtn.setAttribute('type', 'button');
        removeBtn.innerHTML = '-';

        // <input id="routineActID-@i" type="hidden" value="@Model.ActivitiesInRoutine[i]" />

        const actBtnCell = document.createElement('TD');
        actBtnCell.appendChild(removeBtn);

        const actNameCell = document.createElement('TD');
        actNameCell.innerHTML = '<input id="routineActID-' + i + '" type="hidden" value="' + tempArray[i] + '" />';
        actNameCell.innerHTML += getActivityName(tempArray[i]);

        const actRow = document.createElement('TR');
        actRow.appendChild(actBtnCell);
        actRow.appendChild(actNameCell);
        actTable.appendChild(actRow);	
    }

    if (tempArray.length < 1) {
        const actCell = document.createElement('TD');
        actCell.innerHTML = 'Add some activities!';
        const actRow = document.createElement('TR');
        actRow.appendChild(actCell);
        actTable.appendChild(actRow);	
    }

}


// I don't think I'm currently using any of the functions below



let log = {
	date: "2018-12-02",
	creator: "1235",
	activities: [
		[
			'Chest Press',
			'',
			''
		],
		[
			'Lat Pulldown',
			'',
			'3x10'
		],
		[
			'Row',
			'',
			'3x10'
		]
	]
};

function reloadActivities() {
	const unused = document.getElementById('unusedAct');

	while (unused.firstChild) {
		unused.removeChild(unused.firstChild);
	}

    for (let i = 0; i < tempArray.length; i++) {

		const addBtn = document.createElement('BUTTON');
		addBtn.setAttribute('onclick', 'addActBackend(\'' + activities[i] + '\')');
		addBtn.innerHTML = '+';
		
		const actBtnCell = document.createElement('TD');		
		actBtnCell.appendChild(addBtn);
		
		const actNameCell = document.createElement('TD');
		actNameCell.innerHTML = '<div id="unusedActName-' + i + '" onclick="showOptions(' + i + ')">' + activities[i] + '</div>';
		actNameCell.innerHTML += '<input id="unusedActField-' + i + '" class="short" onblur="saveAct(' + i + 
			')" onkeypress="keyCheck(event, ' + i + ')" type="text" value="' + activities[i] + '" style="display: none">';
		actNameCell.innerHTML += '<span id="options-' + i + '" style="display: none"><button onclick="editAct(' + i + 
		')">Rename</button> <button class="warnBtn" onclick="deleteActivity(' + i + 
		')">Delete</button> <button class="cancelBtn" onclick="reloadActivities()">Cancel</button></span>';
	
		const actRow = document.createElement('TR');		
		actRow.appendChild(actBtnCell);
		actRow.appendChild(actNameCell);
		document.getElementById('unusedAct').appendChild(actRow);	
	}}


function loadLogActivities() {
	const logTable = document.getElementById('logTable');

	while (logTable.firstChild) {
		logTable.removeChild(logTable.firstChild);
	}

	// headers	
	const actNameHeader = document.createElement('TH');
	actNameHeader.innerHTML = 'Activity';
	const amtBtnHeader = document.createElement('TH');
	amtBtnHeader.innerHTML = 'Amount';
	const setsBtnHeader = document.createElement('TH');
	setsBtnHeader.innerHTML = 'Sets/Reps';
	
	const headerRow = document.createElement('TR');
	headerRow.appendChild(actNameHeader);
	headerRow.appendChild(amtBtnHeader);
	headerRow.appendChild(setsBtnHeader);
	document.getElementById('logTable').appendChild(headerRow);	

	// data
	for (let i = 0; i < upper.length; i++) {
		const actNameCell = document.createElement('TD');
		actNameCell.innerHTML = '<div id="actName-' + i + '">' + upper[i] + '</div>';
		
		const logAmtBtn = document.createElement('BUTTON');
		logAmtBtn.setAttribute('onclick', 'editAmt(' + i + ')');
		logAmtBtn.setAttribute('id', 'logAmtBtn-' + i);
		logAmtBtn.innerHTML = 'EDIT';		

		const amtBtnCell = document.createElement('TD');
		if (log.activities[i][1] == null || log.activities[i][1] == '')
			amtBtnCell.appendChild(logAmtBtn);
		amtBtnCell.innerHTML += '<div id="amtValue-' + i + '" onclick="editAmt(' + i + ')">' + log.activities[i][1] + '</div>';
		amtBtnCell.innerHTML += '<input id="amtField-' + i + '" class="short" onblur="saveAmt(' + i + 
			')" onkeypress="keyCheckAmt(event, ' + i + ')" type="text" placeholder="e.g. 75" value="' + log.activities[i][1] + '" style="display: none">';
	
		const logSetsBtn = document.createElement('BUTTON');
		logSetsBtn.setAttribute('onclick', 'editSets(' + i + ')');
		logSetsBtn.setAttribute('id', 'logSetsBtn-' + i);
		logSetsBtn.innerHTML = 'EDIT';
		
		const setsBtnCell = document.createElement('TD');
		if (log.activities[i][2] == null || log.activities[i][2] == '')
			setsBtnCell.appendChild(logSetsBtn);
		setsBtnCell.innerHTML += '<div id="setsValue-' + i + '" onclick="editSets(' + i + ')">' + log.activities[i][2] + '</div>';
		setsBtnCell.innerHTML += '<input id="setsField-' + i + '" class="short" onblur="saveSets(' + i + 
			')" onkeypress="keyCheckSets(event, ' + i + ')" type="text" placeholder="e.g. 3x10" value="' + log.activities[i][2] + '" style="display: none">';
	
		const actRow = document.createElement('TR');		
		actRow.appendChild(actNameCell);
		actRow.appendChild(amtBtnCell);
		actRow.appendChild(setsBtnCell);
		document.getElementById('logTable').appendChild(actRow);	
	}

}

function saveAmt(index) {
	log.activities[index][1] = document.getElementById('amtField-' + index).value;
	loadLogActivities();
}

function editSets(index) {
	if (document.getElementById('logSetsBtn-' + index))
		document.getElementById('logSetsBtn-' + index).style.display = 'none';
	document.getElementById('setsValue-' + index).style.display = 'none';
	document.getElementById('setsField-' + index).style.display = 'inline';
	document.getElementById('setsField-' + index).focus();
}

function saveSets(index) {
	log.activities[index][2] = document.getElementById('setsField-' + index).value;
	loadLogActivities();
}

function editAmt(index) {
	if (document.getElementById('logAmtBtn-' + index))
		document.getElementById('logAmtBtn-' + index).style.display = 'none';
	document.getElementById('amtValue-' + index).style.display = 'none';	
	document.getElementById('amtField-' + index).style.display = 'inline';
	document.getElementById('amtField-' + index).focus();
}

function saveAmt(index) {
	log.activities[index][1] = document.getElementById('amtField-' + index).value;
	loadLogActivities();
}

function keyCheck(e, index) {
	evt = e.keyCode || e.charCode;

	if (evt == 13) { // Enter
		document.getElementById('unusedActField-' + index).blur();
	}
}

function keyCheckSets(e, index) {
	evt = e.keyCode || e.charCode;

	if (evt == 13) { // Enter
		document.getElementById('setsField-' + index).blur();
	}
}

function keyCheckAmt(e, index) {
	evt = e.keyCode || e.charCode;

	if (evt == 13) { // Enter
		document.getElementById('amtField-' + index).blur();
	}
}
