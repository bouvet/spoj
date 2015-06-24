import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;

public class Main {

    public static void main(String[] args) throws Exception {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        int size = Integer.parseInt(reader.readLine());
        boolean emptyLine = false;
        while (size-- > 0) {
            if (emptyLine) {
                reader.readLine();
            }
            String input = reader.readLine();
            int split = input.indexOf(' ');
            int[][] grid = new int[Integer.parseInt(input.substring(0, split))][Integer.parseInt(input.substring(split + 1, input.length()))];
            for (int n = 0; n < grid.length; n++) {
                String digest = reader.readLine();
                for (int m = 0; m < grid[n].length; m++) {
                    grid[n][m] = digest.charAt(m) == '1' ? 0 : Integer.MAX_VALUE;
                }
            }
            boolean done;
            int update = 0;
            do {
                done = true;
                for (int n = 0; n < grid.length; n++) {
                    for (int m = 0; m < grid[n].length; m++) {
                        int value = grid[n][m];
                        if (value == Integer.MAX_VALUE) {
                            done = false;
                        } else if (value == update) {
                            for (int i = Math.max(0, n - 1); i < Math.min(grid.length, n + 2); i++) {
                                for (int j = Math.max(0, m - 1); j < Math.min(grid[n].length, m + 2); j++) {
                                    if (i != n ^ j != m) {
                                        grid[i][j] = Math.min(value + 1, grid[i][j]);
                                    }
                                }
                            }
                        }
                    }
                }
                update++;
            } while (!done);
            for (int[] line : grid) {
                for (int value : line) {
                    System.out.print(value);
                    System.out.print(' ');
                }
                System.out.println();
            }
            emptyLine = true;
        }
    }
}
