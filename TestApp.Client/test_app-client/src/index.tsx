import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
import history from './store/history';
import { BrowserHistory } from "history";
import { Router } from "react-router-dom";

type Props = {
  basename?: string;
  children: React.ReactNode;
  history: BrowserHistory;
}

const CustomRouter = ({ basename, children, history }: Props) => {
  const [state, setState] = React.useState({
    action: history.action,
    location: history.location,
  });

  React.useLayoutEffect(() => history.listen(setState), [history])

  return (
    <Router
      basename={basename}
      location={state.location}
      navigator={history}
      navigationType={state.action}
    >
      {children}
    </Router>
  );
};
const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <CustomRouter history={history}>
    <App />
  </CustomRouter>
);

