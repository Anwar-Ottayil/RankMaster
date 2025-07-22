import React, { useState } from 'react';
import Sidebar from './components/Sidebar';
import Dashboard from './components/Dashboard';
import UserManagement from './components/UserManagement';
import ExamManagement from './components/ExamManagement';
import ContentManagement from './components/ContentManagement';
import CoordinatorManagement from './components/CoordinatorManagement';
import Analytics from './components/Analytics';
import Notifications from './components/Notifications';
import RewardsManagement from './components/RewardsManagement';

type ActivePage = 'dashboard' | 'users' | 'exams' | 'content' | 'coordinators' | 'analytics' | 'notifications' | 'rewards';

function App() {
  const [activePage, setActivePage] = useState<ActivePage>('dashboard');

  const renderPage = () => {
    switch (activePage) {
      case 'dashboard':
        return <Dashboard />;
      case 'users':
        return <UserManagement />;
      case 'exams':
        return <ExamManagement />;
      case 'content':
        return <ContentManagement />;
      case 'coordinators':
        return <CoordinatorManagement />;
      case 'analytics':
        return <Analytics />;
      case 'notifications':
        return <Notifications />;
      case 'rewards':
        return <RewardsManagement />;
      default:
        return <Dashboard />;
    }
  };

  return (
    <div className="flex min-h-screen bg-gray-50">
      <Sidebar activePage={activePage} setActivePage={setActivePage} />
      <main className="flex-1 ml-64">
        {renderPage()}
      </main>
    </div>
  );
}

export default App;