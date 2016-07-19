# JiraAgile.NET
.NET client for JIRA agile REST API's (Boards, Sprints, Backlogs)  (/rest/agile/1.0)

## Sample Usage

	// Create a connection using basic auth.
	var client = new AgileClient("http://server_url/", "username", "password");

	// Get the list of boards.
	var boards = await agile.Boards.GetBoards();

	// Get the list of sprints for a board.
	var sprints = await board.Sprints.GetSprints();

	// Get the list of issues for a sprint.
	var issues = await sprint.Issues.GetIssues();
	
	// Get the list of issues for a board.
	var issues = await board.Issues.GetIssues();
	
	// Get the list of backlog issues for a board.
	var issues = await board.BacklogIssues.GetIssues();

## Todo
 * Implement update / delete support.
 
