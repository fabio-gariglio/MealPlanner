import React from 'react';
import { Container } from 'react-bootstrap';
import { BrowserRouter, Switch, Route } from 'react-router-dom';

import { RecipeList } from './components/RecipeList';
import { RecipeDetails } from './components/RecipeDetails';
import { NavMenu } from './components/NavMenu';


export function App(props) {

  return (
    <BrowserRouter basename={props.baseUrl} forceRefresh={false}>
      <NavMenu />
      <Container>
        <Switch>
          <Route path="/about">
            <p>hello</p>
          </Route>
          <Route path="/recipes/:recipeId">
            <RecipeDetails />
          </Route>
          <Route path="/">
            <RecipeList />
          </Route>
        </Switch>
      </Container>
    </BrowserRouter >
  );

};