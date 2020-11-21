import React, { useState, useEffect } from 'react';
import axios from 'axios';

import { RecipeListItem } from './RecipeListItem';

export function RecipeList() {

    const [recipes, setRecipes] = useState([]);

    useEffect(() => {
        async function fetchRecipes() {
            const result = await axios('/api/recipes');
            setRecipes(result.data);
        };
        fetchRecipes();
    }, []);

    return (
        <div>
            {recipes.map(r => (<RecipeListItem {...r} />))}
        </div>
    );

};