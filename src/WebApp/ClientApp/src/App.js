import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { RecipeList } from './components/RecipeList';
import { RecipeDetails } from './components/RecipeDetails';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={RecipeList} />
        <Route path='/recipes/:recipeId' component={RecipeDetails} />            
      </Layout>
    );
  }
}
