#SoftwareQuality 

#### W10 summary

#### **Intro to Software Configuration Management**

- Why do we need it? Software is essentially dynamic: multiple parallel versions, continuously updated, by many developers… Without good tools we need to do it manually (Linus Torvalds did it with tarballs and patches)
- What is Software Configuration Management? It is the discipline that helps to deal with that dynamism and include aspects such as:
    - Source Code Management or Version Control (e.g. Git, SVN, Mercurial…)
    - Bug Tracking (e.g. Bugzilla, Redmine…)
    - Agile Management (e.g. Jira, Trello…)
    - Test Cases Execution Tracking (e.g. Jira)
    - Build System (e.g. Buck)
    - Continuous Integration (e.g. Travis, Jenkins, Gitlab CI…)
    - Continuous Delivery
- Sometimes Software Configuration Management and Source Code Management are confused as the acronym is the same: SCM. Source Code Management is a subset of Software Configuration Management. If you want to do proper Software Configuration Management you need to enrich Source Code Management with other features, for instance, GitHub added other features (issue tracking, GH actions, etc.) to what Git offered.

#### **Source Code Management** 

Not the only part of Software Configuration Management but a critical one:

- Git has become nearly the de-facto standard. Git was created by Linus Torvalds as he needed an SCM distributed system and no free one was distributed (all were centralized). You can watch Linus Torvalds talking about why invented Git and how Git was created at the youtube video I mentioned during our session. A distributed system let developers cooperate directly amongst them without going via a centralized repository.
- We reviewed the concept of repository and workspace. We also checked the key basic Git interactions and the meaning they have. We also learned that most of Git operations (with 3 exceptions) can work without connection.
- We learned that a Git revision identifies uniquely a snapshot of a repository at a given moment of time. A git revision is a hash number, the first seven chars of that hash are enough to identify it. A new revision is created with every commit. A revision number identifies the complete repository at a point of time. Git let developers move from revision to revision with just a single command: git checkout \<revision\>
- We also talked about the branch/merge concepts. We reviewed some tips for branching/merging. The key ideas are working in separate branches and make them as short-lived as possible. We also talked about how Git was designed in order to make merging easy.

#### **Build System and Continuous Integration**

The ideal build system should be 100% automated, centralized (but also allow local builds) and super-fast.

- There are companies that consider building so important that have developed their own build system. For instance, Facebook developed its own build system: Buck (you can watch the video I mentioned in the session).
- In a CI system, the key part is that after every commit a build is created (or all the needed builds) and a set of test cases are automatically executed.  
    
- Having after every commit a clear picture of the status of the build is a great way to know the status of the master branch. Even if the developer tests locally before committing, there is a chance that builds are broken. If a commit breaks the builds (tests are red) the commit should be automatically backed-out (reverted).

#### **Continuous Delivery**

- Releasing is the most important part of software development. If the software is not released it’s meaningless for end-users.
- Nowadays, the need to release new versions to users frequently is increasing.
- Continuous Delivery expands Continuous Integration: It does not only create a build after a commit but it also releases the created build to the end-users. This could look like a risky approach, but if there is a good set of tools in advance, and it’s combined with the gradual rollout, releasing a new version with every commit is doable and the best way to ensure you ship a new version of your product to your customers as soon as possible.